using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerSpawner : MonoBehaviour {
  Player player;
  public GameObject[] objects;
  bool occupied;
  void Awake() {
    player = FindObjectOfType<Player>();
  }
  public void SpawnNewObject(GameObject objectToSpawn, Vector3 spawnPosition) {
    GameObject newObject = Instantiate(objectToSpawn, spawnPosition, player.mouseSlot.gameObject.transform.rotation);
    newObject.SetActive(true);
    player.mouseSlot.SubtractCurrentItem(1);
    player.uiManager.UpdateMouseSlotUI(player.mouseSlot);
  }
  public void PlantSeed(string seedName, RaycastHit groundHitInfo) {
      player.playerSpawner.SpawnNewObject(player.seedDictionary.seedDictionary[seedName], new Vector3(Mathf.Round(groundHitInfo.point.x), groundHitInfo.point.y, Mathf.Round(groundHitInfo.point.z)));
    }
}