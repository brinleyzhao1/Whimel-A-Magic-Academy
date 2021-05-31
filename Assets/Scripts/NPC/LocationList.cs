using UnityEngine;

namespace NPC
{
  //not used now
  public class LocationList : MonoBehaviour
  {

    [Header("iron teacher")]
    [SerializeField] public GameObject setStairs;
    public static GameObject Stairs;




    private void Awake()
    {
      Stairs = setStairs;
    }
  }
}
