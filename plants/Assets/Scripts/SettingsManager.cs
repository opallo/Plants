using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour {
  public int targetFrameRate = 60;
  private void Start() {
    QualitySettings.vSyncCount = 0;
    Application.targetFrameRate = targetFrameRate;
  }
  void Update() {
    if (Input.GetKeyDown(KeyCode.R)) {
      Restart();
    }
    if(Input.GetKeyDown(KeyCode.Escape)){
      Application.Quit();
    }
  }
  public void Restart() {
    SceneManager.LoadScene(0);
  }

}