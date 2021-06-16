// using Player.Interaction;
//
// namespace Crafting
// {
//   public class ForgeTrigger : CraftingTrigger
//   {
//     // private readonly CraftingSystem _craftingSystem = GameAssets.CraftingPanel.GetComponent<CraftingSystem>();
//     protected override void WhenTriggered()
//     {
//       CraftingSystem _craftingSystem = GameAssets.CraftingPanel.GetComponent<CraftingSystem>();
//       base.WhenTriggered();
//       _craftingSystem.alchemyOrForge = CraftingSystem.CraftMode.Forge;
//       FindObjectOfType<CraftingInventoryUi>().alchemyOrForge = CraftingSystem.CraftMode.Forge;
//
//       _craftingSystem.SetProperTitle(CraftingSystem.CraftMode.Forge);
//
//       _craftingSystem.LoadInReceipes();
//     }
//
//   }
// }
