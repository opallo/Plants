using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour {
  Player player;
  GameObject[] objects;
  bool occupied;
  void Awake() {
    player = FindObjectOfType<Player>();
    objects = player.playerSpawner.objects;
    occupied = false;
    SpawnInitialObjects();
  }
  void SpawnInitialObjects() {
    Instantiate(objects[(int)Objects.Grass], transform.position + (Vector3.up * (Random.Range(4f, 6f))), Quaternion.identity);
    RandomSpawn(objects[(int)Objects.Seed], .3f);
    RandomSpawn(objects[(int)Objects.Stone], .3f);
  }
  void RandomSpawn(GameObject newObject, float spawnChance) {
    float rand = Random.Range(0f, 1f);
    if (spawnChance <  rand) {
      if (!occupied) {
        Instantiate(newObject, transform.position + (Vector3.up * (Random.Range(8f, 10f))), newObject.transform.rotation);
        occupied = true;
      }
    }
  }
}