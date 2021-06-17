using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour {
  Player player;
  GameObject[] objects;
  bool occupied;
  [SerializeField] float spawnDelay;
  bool delayedObjectsSpawned;
  void Awake() {
    player = FindObjectOfType<Player>();
    objects = player.playerSpawner.objects;
    occupied = false;
    delayedObjectsSpawned = false;
    SpawnGrass();
  }
  void Update() {
    if (!delayedObjectsSpawned)
      InitialSpawnDelay(ref spawnDelay);
  }
  void SpawnGrass() {
    Instantiate(objects[(int)Objects.Grass], transform.position + (Vector3.up * (Random.Range(10f, 50f))), Quaternion.identity);
  }
  void InitialSpawnDelay(ref float time) {
    time -= Time.deltaTime;
    if (time <= 0) {
      SpawnDelayedObjects();
    }
  }
  void SpawnDelayedObjects() {
    GameObject[] potentialObjectsToSpawn = {
      objects[(int)Objects.Stone],
      objects[(int)Objects.Seed],
      objects[(int)Objects.IzziSeed]
    };
    RandomSpawn(potentialObjectsToSpawn);
    delayedObjectsSpawned = true;
  }
  void RandomSpawn(GameObject[] potentialObjects) {
    int rand = Random.Range(0, potentialObjects.Length);
    Instantiate(potentialObjects[rand], transform.position + (Vector3.up * (Random.Range(10f, 50f))), potentialObjects[rand].transform.rotation);
  }
}