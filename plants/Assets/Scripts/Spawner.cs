using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour {
  [SerializeField] GameObject[] objects;
  void Awake() {
    SpawnInitialObjects();
  }
  void SpawnInitialObjects() {
    Instantiate(objects[(int)Objects.Grass], transform.position + (Vector3.up * (Random.Range(4f, 6f))), Quaternion.identity);
    RandomSpawn(objects[(int)Objects.Seed], .5f);
  }
  void SpawnNewObject() {

  }

  void RandomSpawn(GameObject newObject, float spawnChance){
    if(spawnChance < Random.Range(0f, 1f)){
      Instantiate(newObject, transform.position + (Vector3.up * (Random.Range(8f,10f))), Quaternion.identity);
    }
  }
}