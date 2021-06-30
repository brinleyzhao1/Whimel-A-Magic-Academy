using UI;
using UnityEngine;

namespace Player.Interaction
{
  public class DiningTrigger : TriggerUi
  {
    [SerializeField][TextArea] private string notMealTimeMessage = "Come back during lunch or dinner!s";

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

      // GameAssets.ShopPanel.gameObject.SetActive(true);
      // GameAssets.ShopPanel.GetComponent<ShopMenu>().SetUpShopList(itemsForSell);
      // FindObjectOfType<ShowHideUiWithKey>().OpenOrCloseTabs();
      // FindObjectOfType<SwitchTabs>().SwitchToInventoryTab();


      // GameAssets.SellTray.gameObject.SetActive(true);
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
