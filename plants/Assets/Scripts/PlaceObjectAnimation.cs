using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectAnimation : MonoBehaviour {
  [SerializeField] float moveSpeed;
  [SerializeField] LayerMask groundLayerMask;
  [SerializeField] bool isMoving;
  [SerializeField] static float shakeAmount = .5f;
  [SerializeField] static float shakeTimer = .02f;
  void OnEnable() {
    isMoving = true;
    transform.position += Vector3.up * 4f;
  }
  void Update() {
    RaycastHit hitInfo;
    //Debug.Log(transform.position);

    Physics.Raycast(transform.position, Vector3.down, out hitInfo, Mathf.Infinity, groundLayerMask, QueryTriggerInteraction.Collide);
    // Debug.Log(hitInfo.collider);
    // Debug.Log(hitInfo.distance);
    if (isMoving) {
      if (hitInfo.distance > moveSpeed) {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y - moveSpeed, transform.position.z), moveSpeed);
        //Debug.Log("moving");
      } else {
        transform.position = new Vector3(transform.position.x, transform.position.y - hitInfo.distance, transform.position.z);
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y - hitInfo.distance, transform.position.z), moveSpeed);
        ScreenShake.Instance.ShakeCamera(shakeAmount, shakeTimer);
        isMoving = false;
        //Debug.Log("not moving");
      }
    }
  }

  void OnDrawGizmos() {
    Ray ray = new Ray(transform.position, Vector3.down);
    Gizmos.DrawRay(ray);
  }
}