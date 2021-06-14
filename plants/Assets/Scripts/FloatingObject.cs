using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour {
  public bool readyToFloat { get; set; }
  void Awake() {
    readyToFloat = true;
  }
  void Update() {
    if (readyToFloat)
      transform.position = new Vector3(transform.position.x, transform.position.y + (Mathf.Sin(Time.time * 5f) * .001f), transform.position.z);
  }
}