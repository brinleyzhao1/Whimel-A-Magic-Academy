using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using Player.Interaction;
using UnityEngine;

/// <summary>
/// the script that force player to pay a certain amount of tuition per year
/// </summary>
public class Tuition : MonoBehaviour
{
  //todo: in future each school year can have different tuition
  [SerializeField] private int tuition = 50;

  [SerializeField] [TextArea] private string messageWhenCannotAfford = "Unfortunately since you couldn't afford the tuition you had to drop out.";
  [SerializeField] [TextArea] private string messageWhenCanAffordPart1 = "You need to submit tuition ";
  [SerializeField] [TextArea] private string messageWhenCanAffordPart2 = "c. Your tuition has been deducted from your purse.";

  private void Start()
  {
    TimeManager.Instance.NewSchoolYear += AskForTuition;
    print(1);
  }

  private void AskForTuition()
  {
    // print();
    print(2);
    GameAssets.MessagePanel.gameObject.SetActive(true);
    if (Money.Instance.money < tuition) //if cannot afford
    {
      GameAssets.MessagePanel.SetMessageText(messageWhenCannotAfford);
    }
    else
    {
      GameAssets.MessagePanel.SetMessageText(messageWhenCanAffordPart1+tuition + messageWhenCanAffordPart2);
      Money.Instance.AddOrMinusMoney(-tuition);
    }



  }
}
