// using GameDevTV.Inventories;
// using Player;
// using UnityEngine;
//
// namespace GameDev.tv_Assets.Scripts.Inventories
// {
//   [CreateAssetMenu(menuName = ("GameDevTV/Food Item"))]
//   public class FoodItem : ActionItem
//   {
//
//
//     [Tooltip("Does an instance of this item get consumed every time it's used.")]
//     [SerializeField] int energyChange = 0;
//
//
//     public override void Use(GameObject user)
//     {
//       PlayerEnergy player = FindObjectOfType<PlayerEnergy>();
//       player.AddOrMinusEnergy(energyChange);
//     }
//   }
// }
