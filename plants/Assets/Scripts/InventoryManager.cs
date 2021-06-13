using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
  [SerializeField] UIManager uiManager;
  public Hotbar hotbar;
  //[SerializeField] MouseController mouseController;
  public void AddToInventory(StorableItem currentItem) {
    for (int i = 0; i < hotbar.slots.Length; i++) {
      if (hotbar.slots[i].currentItem == null) {
        hotbar.slots[i].currentItem = currentItem;
        hotbar.slots[i].itemCount += 1;
        uiManager.UpdateSlotUI(ref hotbar.slots[i]);
        //hotbar.slots[i].UpdateUI();
        break;   
      } else if (hotbar.slots[i].currentItem.itemName == currentItem.itemName) {
        hotbar.slots[i].itemCount += 1;
        uiManager.UpdateSlotUI(ref hotbar.slots[i]);
        break;
      } else {

      }
    }
  }
}