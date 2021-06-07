
using System.Net.Mime;
using Player;
using UnityEngine;

namespace Endings
{
  [CreateAssetMenu(fileName = "Ending", menuName = "Scriptables/Ending")]
  public class EndingItem : ScriptableObject
  {
    // [SerializeField] string endingName = null;

  [Header("Conditions")]
    public Stats condition1;
    public int minVal1;

    public Stats condition2;
    public int minVal2;

    public Stats condition3;
    public int minVal3;

    public Stats condition4;
    public int minVal4;

    [Header("Information")] public string description;


  }
}
