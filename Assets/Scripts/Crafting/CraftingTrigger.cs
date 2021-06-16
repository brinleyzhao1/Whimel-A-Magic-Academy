// using Control;
// using Player.Interaction;
// using UI;
//
// namespace Crafting
// {
//   public class CraftingTrigger : TriggerUi
//   {
//
//     protected override void WhenTriggered()
//     {
//       FindObjectOfType<ShowHideUiWithKey>().OpenOrCloseTabs();
//       FindObjectOfType<SwitchTabs>().SwitchToInventoryTab();
//
//       GameAssets.CraftingPanel.SetActive(true);
//
//
//       // FindObjectOfType<ShowHideUiWithKey>().otherUiOut = false; // will be true if want to add some alchemy UI
//       FindObjectOfType<CursorChanger>().numberUiOut += 1;
//       FindObjectOfType<CraftingInventoryUi>().GetComponent<CraftingInventoryUi>().enabled = true;
//
//
//     }
//   }
// }
