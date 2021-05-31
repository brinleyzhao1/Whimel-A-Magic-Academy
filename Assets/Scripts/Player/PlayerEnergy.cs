using System;
using System.Collections;
using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Saving;
using GameDevTV.Saving;
using Player.Movement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
  public class PlayerEnergy : MonoBehaviour, ISaveable
  {
    public int maxEnergy = 100;
    public int currentEnergy = 100;
    [SerializeField] private int energyCostPerHour = 2;

    [Header("UI")]
    [SerializeField] private Image energyBar;

    // private TextMeshProUGUI currentEnergyText;
    // [SerializeField] private TextMeshProUGUI maxEnergyText;

    private void Start()
    {
      UpdateEnergyUi();
    }

    private void Update() //todo test purpose
    {
      if (Input.GetKeyDown(KeyCode.T))
      {
        AddOrMinusEnergy(-30);
      }
    }

    private void UpdateEnergyUi()
    {
      energyBar.fillAmount = currentEnergy / (float)maxEnergy;
      // currentEnergyText.text = currentEnergy.ToString();
      // maxEnergyText.text = maxEnergy.ToString();
    }

    public void AddOrMinusEnergy(int amount)
    {
      currentEnergy += amount;
      if (currentEnergy > maxEnergy)
      {
        currentEnergy = maxEnergy;
      }

      if (currentEnergy < 0)
      {
        currentEnergy = 0;
        ForcedToSleep(10); //todo serialize magic number

      }
      UpdateEnergyUi();
    }

    private void ForcedToSleep(int sleepHour)
    {
      //todo add fade in and message to lwt player know
      //player position
      CharacterController charController =  FindObjectOfType<CharacterController>();
      charController.enabled = false;
      FindObjectOfType<CharacterMovement>().transform.position = new Vector3(-38, 36, -41); //todo fine tune this position
      charController.enabled = true;

      //forced to sleep
      TimeManager.hour  += sleepHour;
      FindObjectOfType<PlayerEnergy>().AddOrMinusEnergy(maxEnergy);
    }

    public void MinusEnergyPerHour()
    {
      AddOrMinusEnergy(-energyCostPerHour);
      if (currentEnergy < 0)
      {
        currentEnergy = 0;
      }
    }

    public object CaptureState()
    {
      int[] energyData = {maxEnergy, currentEnergy};
      // print("energy saved "+currentEnergy);
      return energyData;

    }

    public void RestoreState(object state)
    {
      var energyData = (int[])state;
      maxEnergy = energyData[0];
      currentEnergy = energyData[1];
      UpdateEnergyUi();
      // print("energy restored "+currentEnergy);
    }
  }
}
