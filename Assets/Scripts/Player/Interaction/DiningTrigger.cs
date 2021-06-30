using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Inventories;
using UI;
using UI_Scripts.Dining;
using UnityEngine;

namespace Player.Interaction
{
  public class DiningTrigger : TriggerUi
  {
    [SerializeField][TextArea] private string notMealTimeMessage = "Come back during lunch or dinner!s";


    public List<ActionScriptableItem> lunchMenu = new List<ActionScriptableItem>();
    public List<ActionScriptableItem> dinnerMenu = new List<ActionScriptableItem>();

    private bool isLunchTime;
    private bool isDinnerTime;
    protected override void WhenTriggered()
    {
      CheckIfIsMealTime();

      if (!isLunchTime && !isDinnerTime) //if not in meal time
      {
        GameAssets.MessagePanel.gameObject.SetActive(true);
        GameAssets.MessagePanel.SetMessageText(notMealTimeMessage);
      }

      if (isLunchTime)
      {
        GameAssets.DiningPanel.gameObject.SetActive(true);
        GameAssets.DiningPanel.GetComponent<DiningMenu>().SetUpDiningList(lunchMenu);

      }
      if (isDinnerTime)
      {
        GameAssets.DiningPanel.gameObject.SetActive(true);
        GameAssets.DiningPanel.GetComponent<DiningMenu>().SetUpDiningList(dinnerMenu);

      }
    }

    private void CheckIfIsMealTime()
    {
      //todo abstract magic number
      int time = TimeManager.Hour;
      if (time == 11 ^ time == 12)
      {
        isLunchTime = true;
      }

      if (time == 5 ^ time == 6)
      {
        isDinnerTime = true;
      }
    }
  }
}
