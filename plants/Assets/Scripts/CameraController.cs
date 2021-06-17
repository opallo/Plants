using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour {
  [SerializeField] LayerMask referenceLayerMask;
  [SerializeField] Transform referenceObject;
  Vector3 referenceHitPosition;
  void Update() {
    RaycastHit referenceHitInfo;
    Ray referenceRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    Physics.Raycast(referenceRay, out referenceHitInfo, Mathf.Infinity, referenceLayerMask);
    referenceHitPosition = referenceHitInfo.point;
    FollowMouse();
  }
  void FollowMouse() {
    if (referenceHitPosition != null) {
      referenceObject.position = new Vector3(referenceHitPosition.x, .2f, referenceHitPosition.z);
    }
  }
}