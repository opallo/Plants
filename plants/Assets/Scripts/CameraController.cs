using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour {
  [SerializeField] LayerMask referenceLayerMask;
  [SerializeField] Transform referenceCube;
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
      referenceCube.position = referenceHitPosition;
    }
  }
}