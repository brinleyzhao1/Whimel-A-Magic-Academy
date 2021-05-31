using System.IO;
using UnityEditor;
using UnityEngine;

namespace Endings
{
  [CreateAssetMenu(fileName = "Ending", menuName = "Self Defined/Ending")]
  public class EndingItem : ScriptableObject
  {
    // [SerializeField] string endingName = null;


    public Stats condition1;
    public int minVal1;

    public Stats condition2;
    [SerializeField] public int minVal2;

    public Stats condition3;
    public int minVal3;

    public Stats condition4;
    public int minVal4;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
  }
}
