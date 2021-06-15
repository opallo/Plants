using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
  Player player;
  public Hotbar hotbar;
  //[SerializeField] MouseController mouseController;
  void Awake(){
    player = FindObjectOfType<Player>();
  }
  public void AddToInventory(StorableItem currentItem) {
    for (int i = 0; i < hotbar.slots.Length; i++) {
      if (hotbar.slots[i].currentItem == null) {
        hotbar.slots[i].currentItem = currentItem;
        hotbar.slots[i].itemCount += 1;
        player.uiManager.UpdateSlotUI(hotbar.slots[i]);
        break;   
      } else if (hotbar.slots[i].currentItem.itemName == currentItem.itemName) {
        hotbar.slots[i].itemCount += 1;
        player.uiManager.UpdateSlotUI(hotbar.slots[i]);
        break;
      } else {

      }
    }
  }
}
