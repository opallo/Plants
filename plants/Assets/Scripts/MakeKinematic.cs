﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeKinematic : MonoBehaviour {
  Rigidbody rb;
  void Awake(){
    rb = GetComponent<Rigidbody>();
  }
  void LateUpdate() {
    if (!rb.isKinematic){
      SetKinematic();
    }else{
      GetComponent<MakeKinematic>().enabled = false;
    }
  }
  void SetKinematic() {
    if (rb.velocity.y == 0f) {
      rb.isKinematic = true;
    }
  }
}