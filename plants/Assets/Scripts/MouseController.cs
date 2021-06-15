using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {
  Vector3 groundHitPosition;
  GameObject currentObject;
  MouseSlot mouseSlot;
  PlayerSpawner playerSpawner;
  ObjectNameDictionary objectNameDictionary;
  //-----------------------------------------------------------------
  [Header("LayerMasks")]
  [SerializeField] LayerMask objectLayerMask;
  [SerializeField] LayerMask groundLayerMask;
  //-----------------------------------------------------------------
  [Header("Control Debugging")]
  [SerializeField] bool dragAndDrop;

  void Awake() {
    objectNameDictionary = FindObjectOfType<ObjectNameDictionary>();
    playerSpawner = FindObjectOfType<PlayerSpawner>();
    mouseSlot = FindObjectOfType<MouseSlot>();
  }

  void Update() {
    Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

    RaycastHit objectHitInfo;
    RaycastHit groundHitInfo;

    Physics.Raycast(mouseRay, out groundHitInfo, Mathf.Infinity, groundLayerMask);

    groundHitPosition = groundHitInfo.point;

    if (Input.GetMouseButtonDown(0)) {
      if (groundHitInfo.collider != null && !Physics.Raycast(mouseRay, out objectHitInfo, Mathf.Infinity, objectLayerMask)) {
        if (mouseSlot.currentItem != null) {
          playerSpawner.SpawnNewObject(objectNameDictionary.objectNameDictionary[mouseSlot.currentItem.itemName], new Vector3(Mathf.Round(groundHitInfo.point.x), groundHitInfo.point.y, Mathf.Round(groundHitInfo.point.z)));
        }
      }
    }

    // if (Input.GetMouseButtonDown(0)) {
    //   if (Physics.Raycast(mouseRay, out objectHitInfo, Mathf.Infinity, objectLayerMask)) {
    //     currentObject = objectHitInfo.transform.gameObject;
    //   }
    // }

    // if (dragAndDrop) {
    //   if (Input.GetMouseButton(0) && currentObject != null) {
    //     DragAndDrop();
    //   }
    // }

  }
  void DragAndDrop() {
    if (groundHitPosition != null) {
      currentObject.transform.position = new Vector3(Mathf.Round(groundHitPosition.x), 0f, Mathf.Round(groundHitPosition.z));
    }
    if (Input.GetMouseButtonUp(0)) {
      currentObject = null;
    }
  }
}