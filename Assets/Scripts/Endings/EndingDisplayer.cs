using TMPro;
using UnityEngine;

namespace Endings
{
  public class EndingDisplayer : MonoBehaviour
  {
    ///should be placed on ending panel UI
    ///
    ///
    [SerializeField] private TextMeshProUGUI descriptionText;
    public void DisplayEnding(EndingItem endingItem)
    {
      descriptionText.text = endingItem.description;
      print(endingItem.description);
    }
  }
}
