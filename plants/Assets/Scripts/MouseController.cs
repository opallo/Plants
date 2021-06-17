using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {
  Player player;
  Vector3 groundHitPosition;
  GameObject currentObject;
  //-----------------------------------------------------------------
  [Header("LayerMasks")]
  [SerializeField] LayerMask objectLayerMask;
  [SerializeField] LayerMask groundLayerMask;
  //-----------------------------------------------------------------
  [Header("Control Debugging")]
  [SerializeField] bool dragAndDrop;
  RaycastHit groundHitInfo;
  RaycastHit objectHitInfo;
  void Awake() {
    player = FindObjectOfType<Player>();
  }
  void Update() {
    Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    Physics.Raycast(mouseRay, out groundHitInfo, Mathf.Infinity, groundLayerMask);
    groundHitPosition = groundHitInfo.point;
    if (Input.GetMouseButtonDown(0)) {
      if (groundHitInfo.collider != null && !Physics.Raycast(mouseRay, out objectHitInfo, Mathf.Infinity, objectLayerMask)) {
        if (player.mouseSlot.currentItem != null) {
          player.playerSpawner.SpawnNewObject(player.objectNameDictionary.objectNameDictionary[player.mouseSlot.currentItem.itemName], new Vector3(Mathf.Round(groundHitInfo.point.x), groundHitInfo.point.y, Mathf.Round(groundHitInfo.point.z)));
        }
      }
    } else if (Input.GetMouseButtonDown(1)) {
      if (groundHitInfo.collider != null && !Physics.Raycast(mouseRay, out objectHitInfo, Mathf.Infinity, objectLayerMask)) {
        if (player.mouseSlot.currentItem != null) {
          if (player.mouseSlot.currentItem.itemName == "Seed") {
            PlantSeed();
            //Debug.Log("Planted");
          }
        }
      }
    }

    void PlantSeed() {
      player.playerSpawner.SpawnNewObject(player.playerSpawner.objects[(int)Objects.Tree], new Vector3(Mathf.Round(groundHitInfo.point.x), groundHitInfo.point.y, Mathf.Round(groundHitInfo.point.z)));
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
}