using System;
using System.Linq;
using Control;
using NPC.Dialogue.com.subtegral.dialoguesystem.Runtime;
using Subtegral.DialogueSystem.DataContainers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NPC.Dialogue.Samples.DialogueSystemDemo
{
    public class DialogueParser : MonoBehaviour
    {
        [SerializeField] public DialogueItem dialogue;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private Button choicePrefab;
        [SerializeField] private Transform buttonContainer;
        private CursorChanger _cursorChanger;

        private void Start()
        {
          _cursorChanger = FindObjectOfType<CursorChanger>();

        }

        public void StartNarrative()
        {
          // print("startNarrative");
          // print(dialogue);

          var narrativeData = dialogue.nodeLinks.First(); //Entry point node
          // print(3);
          ProceedToNarrative(narrativeData.TargetNodeGUID);

        }

        private void ProceedToNarrative(string narrativeDataGuid)
        {
          var text = dialogue.dialogueNodeData.Find(x => x.NodeGUID == narrativeDataGuid).DialogueText;
            var choices = dialogue.nodeLinks.Where(x => x.BaseNodeGUID == narrativeDataGuid);
            dialogueText.text = ProcessProperties(text);


            var buttons = buttonContainer.GetComponentsInChildren<Button>();
            for (int i = 0; i < buttons.Length; i++)
            {
                Destroy(buttons[i].gameObject);
            }

            var nodeLinkDatas = choices as NodeLinkData[] ?? choices.ToArray();
            foreach (var choice in nodeLinkDatas)
            {
                var button = Instantiate(choicePrefab, buttonContainer);
                button.GetComponentInChildren<TextMeshProUGUI>().text = ProcessProperties(choice.PortName);
                button.onClick.AddListener(() => ProceedToNarrative(choice.TargetNodeGUID));
            }

            if (!nodeLinkDatas.Any())
            {
              // _cursorChanger.numberUiOut -= 1;
              _cursorChanger.numberUiOut = 0;
              print("number ui out: "+_cursorChanger.numberUiOut);
              gameObject.SetActive(false);
            }
        }

        private string ProcessProperties(string text)
        {
            foreach (var exposedProperty in dialogue.exposedProperties)
            {
                text = text.Replace($"[{exposedProperty.PropertyName}]", exposedProperty.PropertyValue);
            }
            return text;
        }
    }
}
