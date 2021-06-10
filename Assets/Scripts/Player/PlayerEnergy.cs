using System;
using System.Collections;
using System.Collections.Generic;
using Control;
using GameDev.tv_Assets.Scripts.Saving;
using GameDevTV.Saving;
using Player.Movement;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
  public class PlayerEnergy : MonoBehaviour, ISaveable
  {
    public int maxEnergy = 100;
    public int currentEnergy = 100;
    [SerializeField] private int energyCostPerHour = 2;

    [Header("UI")]
    [SerializeField] private Image energyBar;

    [SerializeField] private UiPanelGeneric forcedSleepNotificationPanel;


    // private TextMeshProUGUI currentEnergyText;
    // [SerializeField] private TextMeshProUGUI maxEnergyText;

    private void Start()
    {
      UpdateEnergyUi();
    }

    private void Update() //todo test purpose
    {
      if (Input.GetKeyDown(KeyCode.T))
      {
        ForcedToSleepHours(1);
        // UpdateEnergyByValue(-30);
      }
    }

    private void UpdateEnergyUi()
    {
      energyBar.fillAmount = currentEnergy / (float) maxEnergy;
      // currentEnergyText.text = currentEnergy.ToString();
      // maxEnergyText.text = maxEnergy.ToString();
    }

    public void UpdateEnergyByValue(int amount)
    {
      currentEnergy += amount;
      if (currentEnergy > maxEnergy)
      {
        currentEnergy = maxEnergy;
      }

      if (currentEnergy < 0)
      {
        currentEnergy = 0;
        ForcedToSleepHours(10); //todo change to fast forward sleep to next morning
      }

      UpdateEnergyUi();
    }

    public void MinusEnergyPerHour()
    {
      UpdateEnergyByValue(-energyCostPerHour);
      if (currentEnergy < 0)
      {
        currentEnergy = 0;
      }
    }

    private void ForcedToSleepHours(int sleepHour)
    {
      //todo add fade in and message to let player know

      //bring out force sleep panel
      // FindObjectOfType<CursorChanger>().OneMoreUiOut();
      forcedSleepNotificationPanel.gameObject.SetActive(true);


      //teleport player to their dorm
      CharacterController charController = FindObjectOfType<CharacterController>();
      charController.enabled = false;
      FindObjectOfType<CharacterMovement>().transform.position =
        new Vector3(-38, 36, -41); //todo fine tune this position
      charController.enabled = true;

      //fast-forward time and increase energy
      TimeManager.Hour += sleepHour;
      FindObjectOfType<PlayerEnergy>().UpdateEnergyByValue(maxEnergy);
    }


    public object CaptureState()
    {
      int[] energyData = {maxEnergy, currentEnergy};
      // print("energy saved "+currentEnergy);
      return energyData;
    }

    public void RestoreState(object state)
    {
      var energyData = (int[]) state;
      maxEnergy = energyData[0];
      currentEnergy = energyData[1];
      UpdateEnergyUi();
      // print("energy restored "+currentEnergy);
    }
  }
}
