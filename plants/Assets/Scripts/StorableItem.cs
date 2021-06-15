using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StorableItem : MonoBehaviour /*IPointerClickHandler*/ {
  Player player;
  public string itemName;
  public Sprite itemSprite;

  void Awake() {
    player = FindObjectOfType<Player>();
  }
  // vvv Not working for some reason...
  // void OnPointerClick(PointerEventData eventData) {
  //   if (eventData.button == PointerEventData.InputButton.Left) {
  //     player.inventoryManager.AddToInventory(GetComponent<StorableItem>());
  //     transform.gameObject.SetActive(false);
  //   }
  // }
  void OnMouseDown() {
    player.inventoryManager.AddToInventory(GetComponent<StorableItem>());
    transform.gameObject.SetActive(false);
    //Destroy(transform.gameObject);
    // ^^^ this destroys the original GameObject, could be a problem...
  }
}