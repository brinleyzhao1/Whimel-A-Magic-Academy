
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
    public StatsType condition1;
    public int minVal1;

    public StatsType condition2;
    public int minVal2;

    public StatsType condition3;
    public int minVal3;

    public StatsType condition4;
    public int minVal4;

    [Header("Information")] public string description;


  }
}
