using System.Collections;
using GameDev.tv_Assets.Scripts.Saving;
using Player.Interaction;
using Player.Movement;
using SceneManagement;
using Stats;
using UI_Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
  public class PlayerEnergy : MonoBehaviour, ISaveable
  {
    #region Singleton

    private static PlayerEnergy _instance;

    public static PlayerEnergy Instance => _instance;


    private void Awake()
    {
      if (_instance != null && _instance != this)
      {
        Destroy(this.gameObject);
      }
      else
      {
        _instance = this;
      }
    }

    #endregion

    [Header("Energy")] [SerializeField] public int maxEnergy = 100;
    public int currentEnergy = 100;
    [SerializeField] private int maxOfMaxEnergy = 400;
    [SerializeField] [Range(0, 100)] private int criticalEnergyPoint = 10;
    [SerializeField] private int baseEnergyCostPerHour = 2;

    [SerializeField]
    [Tooltip(
      "the higher stamina, the exponential decrease in energy cost in both static metabolism as well as actibities")]
    [Range(0, 1)]
    private float staminaExponentialFactor = 0.9f;

    [Header("UI")] [SerializeField] [TextArea]
    private string forcedSleepText;

    [SerializeField] [TextArea] private string criticalEnergyText;
    [SerializeField] private Image energyBar;
    [SerializeField] private Image energyBarFill;


    private void Start()
    {
      UpdateEnergyUi();
    }

    private void Update() //todo test purpose
    {
      if (Input.GetKeyDown(KeyCode.T))
      {
        StartCoroutine(ForcedToSleepHours(1));
        // UpdateEnergyByValue(-30);
        // PermanentlyIncreaseEnergyUpperBound(-20);
      }
    }

    private void UpdateEnergyUi()
    {
      energyBarFill.fillAmount = currentEnergy / (float) maxEnergy;
      // currentEnergyText.text = currentEnergy.ToString();
      // maxEnergyText.text = maxEnergy.ToString();
    }

    public void UpdateEnergyByValue(int amount)
    {
      //only if consuming energy does stamina play a role
      if (amount < 0)
      {
        float staminaFactor = Mathf.Pow(staminaExponentialFactor, PlayerStats.Instance.GetStamina());
        currentEnergy = (int) (currentEnergy + amount * staminaFactor);
      }
      else
      {
        currentEnergy += amount;
      }


      //cap at max energy
      if (currentEnergy > maxEnergy)
      {
        currentEnergy = maxEnergy;
      }

      //energy critical?
      if (currentEnergy <= criticalEnergyPoint)
      {
        if (TimeManager.Hour <= 20)
        {
          GameAssets.MessagePanel.gameObject.SetActive(true);
          GameAssets.MessagePanel.SetMessageText(criticalEnergyText);
        }
      }

      //forced to sleep?
      if (currentEnergy < 0)
      {
        currentEnergy = 0;
        StartCoroutine(ForcedToSleepHours(10)); //todo change to fast forward sleep to next morning
      }

      UpdateEnergyUi();
    }

    public void MinusEnergyPerHour()
    {
      UpdateEnergyByValue(-baseEnergyCostPerHour);
      if (currentEnergy < 0)
      {
        currentEnergy = 0;
      }
    }

    public void PermanentlyIncreaseEnergyUpperBound(int amount)
    {
      maxEnergy += amount;
      maxEnergy = Mathf.Clamp(maxEnergy, 0, maxOfMaxEnergy);
      energyBar.GetComponent<RectTransform>().sizeDelta = new Vector2(maxEnergy, 100);
      energyBarFill.GetComponent<RectTransform>().sizeDelta = new Vector2(maxEnergy, 100);
      UpdateEnergyUi();
    }

    private IEnumerator ForcedToSleepHours(int sleepHour)
    {
      Fader fader = FindObjectOfType<Fader>(); //todo abstract out fader to optimize
      yield return fader.FadeOut(0.2f);

      FindObjectOfType<ShowHideUiWithKey>().CloseAllCustomaryUis();

      //bring out force sleep panel
      GameAssets.MessagePanel.gameObject.SetActive(true);
      GameAssets.MessagePanel.SetMessageText(forcedSleepText);

      //teleport player to their dorm
      CharacterController charController = FindObjectOfType<CharacterController>();
      charController.enabled = false;
      FindObjectOfType<CharacterMovement>().transform.position =
        new Vector3(-38, 36, -41); //todo fine tune this position
      charController.enabled = true;

      //fast-forward time and increase energy
      TimeManager.Hour += sleepHour;
      FindObjectOfType<PlayerEnergy>().UpdateEnergyByValue(maxEnergy);

      yield return fader.FadeIn(0.2f);
    }

    #region Saving

    public object CaptureState()
    {
      int[] energyData = {maxEnergy, currentEnergy};
      return energyData;
    }

    public void RestoreState(object state)
    {
      var energyData = (int[]) state;
      maxEnergy = energyData[0];
      currentEnergy = energyData[1];
      UpdateEnergyUi();
    }

    #endregion
  }
}
