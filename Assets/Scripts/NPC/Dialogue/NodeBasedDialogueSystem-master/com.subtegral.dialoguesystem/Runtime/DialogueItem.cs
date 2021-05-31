using System;
using System.Collections.Generic;
using Subtegral.DialogueSystem.DataContainers;
using UnityEngine;

namespace NPC.Dialogue.com.subtegral.dialoguesystem.Runtime
{
    [Serializable] [CreateAssetMenu(fileName = "gialogue", menuName = "dialogue")]
    public class DialogueItem : ScriptableObject
    {
        public List<NodeLinkData> nodeLinks = new List<NodeLinkData>();
        public List<DialogueNodeData> dialogueNodeData = new List<DialogueNodeData>();
        public List<ExposedProperty> exposedProperties = new List<ExposedProperty>();
        public List<CommentBlockData> commentBlockData = new List<CommentBlockData>();
    }
}
