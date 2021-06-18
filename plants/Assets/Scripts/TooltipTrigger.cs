using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
  public string header;
  public string content;
  public void OnPointerEnter(PointerEventData eventData) {
    Slot currentSlot = GetComponent<Slot>();
    if (currentSlot.currentItem != null) {
      header = currentSlot.currentItem.itemName;
      content = currentSlot.currentItem.itemDescription;
      TooltipSystem.Show(content, header);
    }
  }
  public void OnPointerExit(PointerEventData eventData) {
    TooltipSystem.Hide();
  }
}