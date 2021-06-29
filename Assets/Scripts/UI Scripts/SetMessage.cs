using TMPro;
using UnityEngine;

namespace UI
{
  public class SetMessage : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI messageText;

    public void SetMessageText(string message)
    {
      messageText.text = message;
    }
  }
}
