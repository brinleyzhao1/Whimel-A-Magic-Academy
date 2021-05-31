using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DestinationChange : MonoBehaviour
{
  public int xPos;
  public int zPos;


  void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("NPC"))
    {
      xPos = Random.Range(-45,-40);
      zPos = Random.Range(-8, -15);
      this.gameObject.transform.position = new Vector3(xPos, transform.position.y, zPos);
    }
  }
}
