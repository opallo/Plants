using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerSpawner : MonoBehaviour {
  public GameObject[] objects;
  UIManager uiManager;
  MouseSlot mouseSlot;
  bool occupied;
  void Awake() {
    uiManager = FindObjectOfType<UIManager>();
    mouseSlot = FindObjectOfType<MouseSlot>();
  }
  public void SpawnNewObject(GameObject objectToSpawn, Vector3 spawnPosition) {
    GameObject newObject = Instantiate(mouseSlot.currentItem.gameObject, spawnPosition, mouseSlot.gameObject.transform.rotation);
    newObject.SetActive(true);
    mouseSlot.SubtractCurrentItem(1);
    uiManager.UpdateMouseSlotUI(mouseSlot);
  }
}