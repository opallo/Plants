using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedDictionary : MonoBehaviour {
  public Dictionary<string, GameObject> seedDictionary = new Dictionary<string, GameObject>();
  Player player;
  void Start() {
    player = FindObjectOfType<Player>();

    //Debug.Log(player.playerSpawner.objects[0]);
    seedDictionary.Add("Seed", player.playerSpawner.objects[(int)Objects.Tree]);
    seedDictionary.Add("IzziSeed", player.playerSpawner.objects[(int)Objects.IzziPlanted]);
  }

}