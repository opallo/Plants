using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  public SettingsManager settingsManager;
  public MouseController mouseController;
  public InventoryManager inventoryManager;
  public UIManager uiManager;
  public PlayerSpawner playerSpawner;
  public ObjectNameDictionary objectNameDictionary;
  public MouseSlot mouseSlot;
  void Awake() {
    settingsManager = FindObjectOfType<SettingsManager>();
    mouseController = FindObjectOfType<MouseController>();
    inventoryManager = FindObjectOfType<InventoryManager>();
    uiManager = FindObjectOfType<UIManager>();
    playerSpawner = FindObjectOfType<PlayerSpawner>();
    objectNameDictionary = FindObjectOfType<ObjectNameDictionary>();
    mouseSlot = FindObjectOfType<MouseSlot>();
  }
}