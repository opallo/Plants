using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour {
  [SerializeField] Sprite nullSprite;
  public void UpdateSlotUI(ref Slot slot) {
    if (slot.currentItem == null) {
      slot.icon.sprite = nullSprite;
      slot.itemCountText.text = "";
    } else {
      slot.icon.sprite = slot.currentItem.itemSprite;
      slot.itemCountText.text = slot.itemCount.ToString();
    }
  }
  public void UpdateMouseSlotUI(ref MouseSlot mouseSlot) {
    if (mouseSlot.currentItem == null) {
      mouseSlot.icon.sprite = nullSprite;
      mouseSlot.itemCountText.text = "";
    } else {
      mouseSlot.icon.sprite = mouseSlot.currentItem.itemSprite;
      mouseSlot.itemCountText.text = mouseSlot.itemCount.ToString();
    }
  }
}