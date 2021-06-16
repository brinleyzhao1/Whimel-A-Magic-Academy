// using Player.Interaction;
//
// namespace Crafting
// {
//   public class AlchemyTrigger : CraftingTrigger
//   {
//
//     protected override void WhenTriggered()
//     {
//       CraftingSystem craftingSystem = GameAssets.CraftingPanel.GetComponent<CraftingSystem>();
//       base.WhenTriggered();
//       craftingSystem.alchemyOrForge = CraftingSystem.CraftMode.Alchemy;
//       FindObjectOfType<CraftingInventoryUi>().alchemyOrForge = CraftingSystem.CraftMode.Alchemy;
//
//       craftingSystem.SetProperTitle(CraftingSystem.CraftMode.Alchemy);
//
//       craftingSystem.LoadInReceipes();
//     }
//
//
//   }
// }
