using System;
using System.Collections;
using System.Collections.Generic;
using Control;
using GameDev.tv_Assets.Scripts.Inventories;
using NPC.Dialogue;
using NPC.Dialogue.com.subtegral.dialoguesystem.Runtime;
using UnityEngine;
using Random = UnityEngine.Random;
// using Random = System.Random;

namespace NPC
{
  public class RandolyChooseOneDialogue : NpcInteract
  {

    public List<DialogueItem> dialogues = new List<DialogueItem>();


    protected override void OnClick()
    {
      thisDialogue = GetRandomDialogue();
      base.OnClick();

      //todo keep adding numberuiout so cannot get camera back 
    }

    private DialogueItem GetRandomDialogue()
    {
      int randomInt = Random.Range(0, 3);
      print(randomInt);
      return dialogues[randomInt];

    }

  }
}
