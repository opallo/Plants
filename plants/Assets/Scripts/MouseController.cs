using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {
  Vector3 groundHitPosition;
  GameObject currentObject;
  //-----------------------------------------------------------------
  [Header("LayerMasks")]
  [SerializeField] LayerMask objectLayerMask;
  [SerializeField] LayerMask groundLayerMask;
  //-----------------------------------------------------------------
  [Header("Control Debugging")]
  [SerializeField] bool dragAndDrop;

  void Update() {
    Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

    RaycastHit objectHitInfo;
    RaycastHit groundHitInfo;

    Physics.Raycast(mouseRay, out groundHitInfo, Mathf.Infinity, groundLayerMask);

    groundHitPosition = groundHitInfo.point;

    if (Physics.Raycast(mouseRay, out objectHitInfo, Mathf.Infinity, objectLayerMask)) {
      if (Input.GetMouseButtonDown(0)) {
        currentObject = objectHitInfo.transform.gameObject;
      }
    }

    /*
    if (dragAndDrop) {
      if (Input.GetMouseButton(0) && currentObject != null) {
        DragAndDrop();
      }
    }
    */
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