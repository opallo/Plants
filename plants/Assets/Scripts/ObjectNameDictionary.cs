using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectNameDictionary : MonoBehaviour {
  public Dictionary<string, GameObject> objectNameDictionary = new Dictionary<string, GameObject>();

  Player player;

  void Awake() {
    player = FindObjectOfType<Player>();
    objectNameDictionary.Add("Seed", player.playerSpawner.objects[(int)Objects.Seed]);
    objectNameDictionary.Add("Stone", player.playerSpawner.objects[(int)Objects.Stone]);
  }
}