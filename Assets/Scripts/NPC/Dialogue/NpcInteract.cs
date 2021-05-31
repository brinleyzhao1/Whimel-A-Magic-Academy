using System;
using Control;
using NPC.Dialogue.com.subtegral.dialoguesystem.Runtime;
using NPC.Dialogue.Samples.DialogueSystemDemo;
using Player.Interaction;
using Subtegral.DialogueSystem.DataContainers;
using UI;
using UnityEngine;

namespace NPC.Dialogue
{
  public class NpcInteract : MonoBehaviour
  {
    private GameObject dialogueUi;
    [SerializeField] public DialogueItem thisDialogue;


    private void Start()
    {
      dialogueUi = GameAssets.DialogueUi;
    }

    private void OnMouseOver()
    {
      if (Input.GetMouseButtonDown(1))
      {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5))
        {
          OnClick();
        }
      }
    }

    protected virtual void OnClick()
    {
      FindObjectOfType<CursorChanger>().OneMoreUiOut();
      Conversation(thisDialogue);
    }


    protected void Conversation(DialogueItem dialogueItem)
    {
      dialogueUi.SetActive(true);
      DialogueParser dialogueParser = dialogueUi.GetComponent<DialogueParser>();
      dialogueParser.dialogue = dialogueItem;
      dialogueParser.StartNarrative();
    }

  }
}
