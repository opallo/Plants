using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorableItem : MonoBehaviour
{
    InventoryManager inventoryManager;
    public string itemName;
    public Sprite itemSprite;

    void Awake(){
      inventoryManager = FindObjectOfType<InventoryManager>();
    }
    void OnMouseDown(){
      inventoryManager.AddToInventory(GetComponent<StorableItem>());
      transform.gameObject.SetActive(false);
      //Destroy(transform.gameObject);
      // ^^^ this destroys the original GameObject, could be a problem...
    }
}
