// using Player.Interaction;
//
// namespace Crafting
// {
//   public class ForgeTrigger : CraftingTrigger
//   {
//     // private readonly CraftingSystem _craftingSystem = GameAssets.CraftingPanel.GetComponent<CraftingSystem>();
//     protected override void Interact()
//     {
//       CraftingSystem _craftingSystem = GameAssets.CraftingPanel.GetComponent<CraftingSystem>();
//       base.Interact();
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
