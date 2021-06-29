using Control;
using Player;
using TMPro;
using UnityEngine;

namespace UI
{
  public class SleepUi : MonoBehaviour
  {
    private int sleepHour = 1;

    [SerializeField] private TextMeshProUGUI sleepHourText;
    [SerializeField] private int energyRefillPerHourSleep = 5;


    public void Add1Hour() // for button
    {
      AddOrSubtractSleepHour(1);
    }

    public void Subtract1Hour() // for button
    {
      AddOrSubtractSleepHour(-1);
    }

    public void HideSleepPanel()
    {
      sleepHour = 1;
      UpdateSleepHourText();

      FindObjectOfType<CursorChanger>().OneLessUiOut();
      gameObject.SetActive(false);
    }

    public void SleepAndFastForwardTime() //for buttons
    {
      TimeManager.Hour  += sleepHour;
      FindObjectOfType<PlayerEnergy>().UpdateEnergyByValue(sleepHour * energyRefillPerHourSleep);
      HideSleepPanel();
    }


    /// <summary>
    /// private methods
    /// </summary>
    /// <param name="hour"></param>
    private void AddOrSubtractSleepHour(int hour)
    {
      sleepHour += hour;
      UpdateSleepHourText();
    }

    private void UpdateSleepHourText()
    {
      sleepHourText.text = sleepHour.ToString();
    }


  }
}
