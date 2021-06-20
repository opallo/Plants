using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour {
  //private static Grow current;
  Player player;
  [SerializeField] GameObject[] phases;
  [SerializeField] float[] phaseDurations;
  float[] modifiablePhaseDurations;
  [SerializeField] int currentPhase;
  float currentPhaseTimer;
  bool fullyGrown;
  void OnEnable() {
    //current = this;
    phases[0].SetActive(true);
    phases[1].SetActive(false);
    phases[2].SetActive(false);
    currentPhase = 0;
    modifiablePhaseDurations = new float[phases.Length - 1];
    for (int i = 0; i < phaseDurations.Length; i++) {
      modifiablePhaseDurations[i] = phaseDurations[i];
    }
  }
  void Update() {
    if (!fullyGrown) {
      GrowTimer(modifiablePhaseDurations);
    }
  }
  // vvv GrowTimer() will currently modify actual timer values (potentially bad), consider making an array of length phases.length with new safely modifiable phaseTimers corresponding to the originals
  void GrowTimer(float[] modifiablePhaseDurations) {
    modifiablePhaseDurations[currentPhase] -= Time.deltaTime;
    if(modifiablePhaseDurations[currentPhase] <= 0f){
      phases[currentPhase].SetActive(false);
      phases[currentPhase + 1].SetActive(true);
      currentPhase++;
      if(currentPhase == phases.Length - 1){
        fullyGrown = true;
      }
    }
  }
}