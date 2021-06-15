using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
  Player player;
  //[SerializeField] MouseController mouseController;
  void Awake(){
    player = FindObjectOfType<Player>();
  }
  public void AddToInventory(StorableItem currentItem) {
    for (int i = 0; i < player.hotbar.slots.Length; i++) {
      if (player.hotbar.slots[i].currentItem == null) {
        player.hotbar.slots[i].currentItem = currentItem;
        player.hotbar.slots[i].itemCount += 1;
        player.uiManager.UpdateSlotUI(player.hotbar.slots[i]);
        break;   
      } else if (player.hotbar.slots[i].currentItem.itemName == currentItem.itemName) {
        player.hotbar.slots[i].itemCount += 1;
        player.uiManager.UpdateSlotUI(player.hotbar.slots[i]);
        break;
      } else {
      }
    }
  }
}
