using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectInfo : MonoBehaviour /*IPointerClickHandler*/ {
  Player player;
  public string itemName;
  public string itemType;
  public Sprite itemSprite;
  public bool seed;

  void Start() {
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
    if (GetComponent<ObjectInfo>().itemType == "Storable") {
      player.inventoryManager.AddToInventory(GetComponent<ObjectInfo>());
      transform.gameObject.SetActive(false);
    }
    //Destroy(transform.gameObject);
    // ^^^ this destroys the original GameObject, could be a problem...
  }
}