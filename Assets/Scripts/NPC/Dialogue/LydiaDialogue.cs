using NPC.Dialogue.com.subtegral.dialoguesystem.Runtime;
using Subtegral.DialogueSystem.DataContainers;
using TMPro;
using UnityEngine;

namespace NPC.Dialogue
{
  public class LydiaDialogue : MonoBehaviour
  {
    [SerializeField] private DialogueItem Lydia;
    [SerializeField] private TextMeshProUGUI dialogueText;

    // Start is called before the first frame update
    void Start()
    {
      var a = Lydia.nodeLinks;
      foreach (var node in Lydia.nodeLinks)
      {
        print(node.PortName);
      }

    }

  }
}
