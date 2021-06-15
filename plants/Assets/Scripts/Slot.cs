using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Slot : MonoBehaviour, /*IPointerDownHandler,*/ IPointerClickHandler {
  [SerializeField] UIManager uiManager;
  public StorableItem currentItem;
  public int itemCount;
  public Image icon;
  public TextMeshProUGUI itemCountText;
  MouseSlot mouseSlot;
  void Awake() {
    uiManager = FindObjectOfType<UIManager>();
    mouseSlot = FindObjectOfType<MouseSlot>();
  }

  public void OnPointerClick(PointerEventData eventData) {
    // Left Click
    if (eventData.button == PointerEventData.InputButton.Left) {
      if (currentItem != null && mouseSlot.currentItem == null) {
        GiveToMouseSlot();
        // Scenarios 3, 4a, & 4b
      } else if (mouseSlot.currentItem != null) {
        // Scenarios 3 & 4a
        if ((currentItem == null) || (currentItem.name == mouseSlot.currentItem.name)) {
          TakeFromMouseSlot();
          // Scenario 4b
        } else {
          SwapItems();
        }
      }
      Slot thisSlot = GetComponent<Slot>();
      uiManager.UpdateSlotUI(thisSlot);
      uiManager.UpdateMouseSlotUI(mouseSlot);
    // Middle Click
    } else if (eventData.button == PointerEventData.InputButton.Middle) { 
    // Right Click
    } else if (eventData.button == PointerEventData.InputButton.Right) {

    }
  }
  void GiveToMouseSlot() {
    // If there is NOTHING in mouseSlot, give mouse hotbar items (handles scenario 2)
    mouseSlot.currentItem = currentItem;
    mouseSlot.itemCount = itemCount;
    currentItem = null;
    itemCount = 0;
  }
  void TakeFromMouseSlot() {
    // If there is NOTHING in hotbar slot OR the same item as in mouseSlot, TAKE/ADD items FROM mouseSlot (handles scenarios 3 and 4a)
    currentItem = mouseSlot.currentItem;
    itemCount += mouseSlot.itemCount;
    mouseSlot.currentItem = null;
    mouseSlot.itemCount = 0;
  }
  void SwapItems() {
    // If there is SOMETHING in BOTH hotbar AND mouse AND the items are DIFFERENT, swap items (handles scenario 4b)
    StorableItem tempMouseCurrentItem = mouseSlot.currentItem;
    int tempMouseItemCount = mouseSlot.itemCount;
    mouseSlot.currentItem = currentItem;
    mouseSlot.itemCount = itemCount;
    currentItem = tempMouseCurrentItem;
    itemCount = tempMouseItemCount;
  }
}