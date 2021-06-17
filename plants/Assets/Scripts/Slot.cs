using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Slot : MonoBehaviour, /*IPointerDownHandler,*/ IPointerClickHandler {
  Player player;
  public ObjectInfo currentItem;
  public int itemCount;
  public Image icon;
  public TextMeshProUGUI itemCountText;
  void Awake() {
    player = FindObjectOfType<Player>();
  }
  public void OnPointerClick(PointerEventData eventData) {
    // vvv Left Click
    if (eventData.button == PointerEventData.InputButton.Left) {
        // Scenario 2
      if (currentItem != null && player.mouseSlot.currentItem == null) {
        GiveToMouseSlot();
        // Scenarios 3, 4a, & 4b
      } else if (player.mouseSlot.currentItem != null) {
        // Scenarios 3 & 4a
        if ((currentItem == null) || (currentItem.name == player.mouseSlot.currentItem.name)) {
          TakeFromMouseSlot();
          // Scenario 4b
        } else {
          SwapItems();
        }
      }
      Slot thisSlot = GetComponent<Slot>();
      player.uiManager.UpdateSlotUI(thisSlot);
      player.uiManager.UpdateMouseSlotUI(player.mouseSlot);
    // vvv Middle Click
    } else if (eventData.button == PointerEventData.InputButton.Middle) { 
    // vvv Right Click
    } else if (eventData.button == PointerEventData.InputButton.Right) {

    }
  }
  void GiveToMouseSlot() {
    // If there is NOTHING in player.mouseSlot & SOMETHING in the hotbar, give mouse hotbar items (handles scenario 2)
    player.mouseSlot.currentItem = currentItem;
    player.mouseSlot.itemCount = itemCount;
    currentItem = null;
    itemCount = 0;
  }
  void TakeFromMouseSlot() {
    // If there is NOTHING in hotbar slot OR the same item as in player.mouseSlot, TAKE/ADD items FROM player.mouseSlot (handles scenarios 3 and 4a)
    currentItem = player.mouseSlot.currentItem;
    itemCount += player.mouseSlot.itemCount;
    player.mouseSlot.currentItem = null;
    player.mouseSlot.itemCount = 0;
  }
  void SwapItems() {
    // If there is SOMETHING in BOTH hotbar AND mouse AND the items are DIFFERENT, swap items (handles scenario 4b)
    ObjectInfo tempMouseCurrentItem = player.mouseSlot.currentItem;
    int tempMouseItemCount = player.mouseSlot.itemCount;
    player.mouseSlot.currentItem = currentItem;
    player.mouseSlot.itemCount = itemCount;
    currentItem = tempMouseCurrentItem;
    itemCount = tempMouseItemCount;
  }
}