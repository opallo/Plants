using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeKinematic : MonoBehaviour {
  Rigidbody rb;
  void Start() {
    rb = GetComponent<Rigidbody>();
  }
  void LateUpdate() {
    if (!rb.isKinematic) {
      SetKinematic();
    } else {
      if (TryGetComponent<FloatingObject>(out FloatingObject floatingObject)) {
        floatingObject.readyToFloat = true;
      }
      GetComponent<MakeKinematic>().enabled = false;
    }
  }
  void SetKinematic() {
    if (rb.velocity.y == 0f) {
      rb.isKinematic = true;
    }
  }
}