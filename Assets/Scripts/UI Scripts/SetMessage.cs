using TMPro;
using UnityEngine;

namespace UI_Scripts
{
  public class SetMessage : ClassPanelUi
  {
    [SerializeField] private TextMeshProUGUI messageText;

    public void SetMessageText(string message)
    {
      messageText.text = message;
    }
  }
}
