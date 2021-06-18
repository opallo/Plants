using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ScreenShake : MonoBehaviour {
  public static ScreenShake Instance {get; private set;}
  CinemachineVirtualCamera cinemachineVirtualCamera;
  private float shakeTimer;
  void Start() {
    Instance = this;
    cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
  }

  public void ShakeCamera(float intensity, float time) {
    CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
    shakeTimer = time;
  }

  void Update() {
    shakeTimer -= Time.deltaTime;
    if (shakeTimer <= 0f) {
      CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
      cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
    }
  }
}