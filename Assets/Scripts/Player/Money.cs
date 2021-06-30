using System;
using Control;
using GameDev.tv_Assets.Scripts.Saving;
using TMPro;
using UnityEngine;

namespace Player
{
  public class Money : MonoBehaviour, ISaveable
  {
    #region Singleton

    private static Money _instance;

    public static Money Instance => _instance;


    private void Awake()
    {
      if (_instance != null && _instance != this)
      {
        Destroy(gameObject);
      }
      else
      {
        _instance = this;
      }
    }

    #endregion


    [SerializeField] private TextMeshProUGUI moneyText;

    public int money;


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
