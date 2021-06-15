using GameDev.tv_Assets.Scripts.Inventories;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameDev.tv_Assets.Scripts.UI.Inventories
{
    /// <summary>
    /// To be put on the icon representing an inventory item. Allows the slot to
    /// update the icon and number.
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class InventoryItemIconInChild : MonoBehaviour
    {
        // CONFIG DATA
        [Tooltip("child: Image")]
        [SerializeField] GameObject roundDotImage = null;
        [Tooltip("child: Text")]
        [SerializeField] TextMeshProUGUI itemNumber = null;

        // PUBLIC

        public void SetItem(InventoryItem item)
        {
            SetItem(item, 0);
        }

        public void SetItem(InventoryItem item, int number)
        {
            var iconImage = GetComponent<Image>();
            //set up item image
            if (item == null)
            {
                iconImage.enabled = false;
            }
            else
            {
                iconImage.enabled = true;

                iconImage.sprite = item.GetIcon();
            }

            //set up  number image
            if (itemNumber)
            {
                if (number <= 1)
                {
                    roundDotImage.SetActive(false);
                }
                else
                {
                    roundDotImage.SetActive(true);
                    itemNumber.text = number.ToString();
                }
            }



        }
    }
}
