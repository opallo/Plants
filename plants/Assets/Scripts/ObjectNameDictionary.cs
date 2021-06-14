using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectNameDictionary : MonoBehaviour {
  public Dictionary<string, GameObject> objectNameDictionary = new Dictionary<string, GameObject>();

  PlayerSpawner playerSpawner;

  void Awake() {
    playerSpawner = FindObjectOfType<PlayerSpawner>();
    objectNameDictionary.Add("Seed", playerSpawner.objects[(int)Objects.Seed]);
    objectNameDictionary.Add("Stone", playerSpawner.objects[(int)Objects.Stone]);
  }
}