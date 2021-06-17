using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectNameDictionary : MonoBehaviour {
  public Dictionary<string, GameObject> objectNameDictionary = new Dictionary<string, GameObject>();
  Player player;
  void Awake() {
    player = FindObjectOfType<Player>();
    UpdateDictionary();
  }

  void UpdateDictionary(){
    for(int i = 0; i < player.playerSpawner.objects.Length; i++){
      objectNameDictionary.Add(player.playerSpawner.objects[i].GetComponent<ObjectInfo>().itemName, player.playerSpawner.objects[i]);
    }
  }
}