using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour {
  [SerializeField] private GameObject dirtBlock;
  [SerializeField] private Spawner spawner;
  [SerializeField] private int width;
  [SerializeField] private int height;
  void Awake() {
    SpawnBlocks(width, height);
  }
  void SpawnBlocks(int width, int height) {
    for (int i = 0; i < width; i++) {
      for (int j = 0; j < height; j++) {
        Instantiate(dirtBlock, new Vector3(i, -.5f, j), Quaternion.identity);
        Instantiate(spawner, new Vector3(i, -.5f, j), Quaternion.identity);
      }
    }
  }
}