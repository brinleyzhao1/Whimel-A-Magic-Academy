using System;
using Control;
using GameDev.tv_Assets.Scripts.Saving;
using TMPro;
using UnityEngine;

namespace Player
{
  public class Money : MonoBehaviour, ISaveable
  {
    [SerializeField] private TextMeshProUGUI moneyText;

    [SerializeField] private int money;

    private void Start()
    {
      UpdateMoneyUi();
    }

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.M)) //todo testing
      {
        AddOrMinusMoney(5);
      }
    }

    public void AddOrMinusMoney(int amount)
    {
      money += amount;
      if (money < 0)
      {
        money = 0;
      }
      UpdateMoneyUi();
    }

    private void UpdateMoneyUi()
    {
      moneyText.text = money.ToString();
    }



    public object CaptureState()
    {
      return money;
    }

    public void RestoreState(object state)
    {
      money = (int) state;
      UpdateMoneyUi();
    }
  }
}
