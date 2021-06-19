using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour {
  Player player;
  bool occupied;
  [SerializeField] float spawnDelay;
  bool delayedObjectsSpawned;
  void Start() {
    player = FindObjectOfType<Player>();
    occupied = false;
    delayedObjectsSpawned = false;
    SpawnGrass();
  }
  void Update() {
    if (!delayedObjectsSpawned)
      InitialSpawnDelay(ref spawnDelay);
  }
  void SpawnGrass() {
    Instantiate(player.playerSpawner.objects[(int)Objects.Grass], transform.position + (Vector3.up * (Random.Range(10f, 50f))), Quaternion.identity);
  }
  void InitialSpawnDelay(ref float time) {
    time -= Time.deltaTime;
    if (time <= 0) {
      SpawnDelayedObjects();
    }
  }
  void SpawnDelayedObjects() {
    GameObject[] potentialObjectsToSpawn = {
      player.playerSpawner.objects[(int)Objects.Stone],
      player.playerSpawner.objects[(int)Objects.Seed],
      player.playerSpawner.objects[(int)Objects.IzziSeed],
      player.playerSpawner.objects[(int)Objects.Water]
    };
    RandomSpawn(potentialObjectsToSpawn);
    delayedObjectsSpawned = true;
  }
  void RandomSpawn(GameObject[] potentialObjects) {
    int rand = Random.Range(0, potentialObjects.Length);
    Instantiate(potentialObjects[rand], transform.position + (Vector3.up * (Random.Range(10f, 50f))), potentialObjects[rand].transform.rotation);
  }
}