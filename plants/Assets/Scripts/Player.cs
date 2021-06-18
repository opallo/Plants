using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour {
  public SettingsManager settingsManager;
  public MouseController mouseController;
  public InventoryManager inventoryManager;
  public UIManager uiManager;
  public PlayerSpawner playerSpawner;
  public ObjectNameDictionary objectNameDictionary;
  public SeedDictionary seedDictionary;
  public MouseSlot mouseSlot;
  public Hotbar hotbar;
  public TextMeshProUGUI toolTip;
  void Awake() {
    settingsManager = FindObjectOfType<SettingsManager>();
    mouseController = FindObjectOfType<MouseController>();
    inventoryManager = FindObjectOfType<InventoryManager>();
    uiManager = FindObjectOfType<UIManager>();
    playerSpawner = FindObjectOfType<PlayerSpawner>();
    objectNameDictionary = FindObjectOfType<ObjectNameDictionary>();
    seedDictionary = FindObjectOfType<SeedDictionary>();
    mouseSlot = FindObjectOfType<MouseSlot>();
    hotbar = FindObjectOfType<Hotbar>();
    toolTip = FindObjectOfType<TextMeshProUGUI>();
  }
}