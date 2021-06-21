using System;
using System.Collections;
using System.Collections.Generic;
using SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
  public class PauseMenuUi : MonoBehaviour
  {

    private void OnEnable()
    {
      //pause time
      Time.timeScale = 0;
    }

    private void OnDisable()
    {
      //unpause time
      Time.timeScale = 1;
    }

    public void ButtonReturnToMainMenu()
    {
      //save
     var savingWrapper =  FindObjectOfType<SavingWrapper>();
     // savingWrapper.Save	();
     savingWrapper.LoadMenu	();


    }


  }
}
