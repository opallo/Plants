using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour {
  void Awake() {
#if UNITY_EDITOR
    QualitySettings.vSyncCount = 0; // VSync must be disabled
    Application.targetFrameRate = 60;
#endif
  }
}