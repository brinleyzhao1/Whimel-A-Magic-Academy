// using Control;
// using UI;
// using UnityEngine;
//
// namespace Alchemy
// {
//   public class AlchemyTrigger : Interactable
//   {
//     [SerializeField] private GameObject alchemySystem;
//     protected override void Interact()
//     {
//
//       FindObjectOfType<ShowHideUiWithKey>().OpenOrCloseTabs();
//       FindObjectOfType<SwitchTabs>().SwitchToInventoryTab();
//
//       alchemySystem.SetActive(true);
//       // FindObjectOfType<AlchemySystem>().gameObject.SetActive(true);//todo game asset
//
//       // FindObjectOfType<ShowHideUiWithKey>().otherUiOut = false; // will be true if want to add some alchemy UI
//       FindObjectOfType<CursorChanger>().numberUiOut += 1;
//       FindObjectOfType<AlchemyInventoryUi>().GetComponent<AlchemyInventoryUi>().enabled = true;
//     }
//   }
// }
