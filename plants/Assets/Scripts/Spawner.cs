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
  void SpawnDelayedObjects() {
    RandomSpawn(objects[(int)Objects.Flower], .0001f);
    RandomSpawn(objects[(int)Objects.Seed], .3f);
    RandomSpawn(objects[(int)Objects.Stone], .3f);
  }
  void RandomSpawn(GameObject newObject, float spawnChance) {
    float rand = Random.Range(0f, 1f);
    if (spawnChance < rand) {
      if (!occupied) {
        Instantiate(newObject, transform.position + (Vector3.up * (Random.Range(10f, 50f))), newObject.transform.rotation);
        occupied = true;
      }
    }
  }
  void InitialSpawnDelay(ref float time) {
    time -= Time.deltaTime;
    if (time <= 0) {
      SpawnDelayedObjects();
      delayedObjectsSpawned = true;
    }
  }
}