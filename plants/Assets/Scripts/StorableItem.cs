using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StorableItem : MonoBehaviour /*IPointerClickHandler*/ {
  InventoryManager inventoryManager;
  public string itemName;
  public Sprite itemSprite;

  void Awake() {
    inventoryManager = FindObjectOfType<InventoryManager>();
  }
  // vvv Not working for some reason...
  // void OnPointerClick(PointerEventData eventData) {
  //   if (eventData.button == PointerEventData.InputButton.Left) {
  //     inventoryManager.AddToInventory(GetComponent<StorableItem>());
  //     transform.gameObject.SetActive(false);
  //   }
  // }
  void OnMouseDown() {
    inventoryManager.AddToInventory(GetComponent<StorableItem>());
    transform.gameObject.SetActive(false);
    //Destroy(transform.gameObject);
    // ^^^ this destroys the original GameObject, could be a problem...
  }
}