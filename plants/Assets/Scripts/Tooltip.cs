using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour {
  public TextMeshProUGUI headerField;
  public TextMeshProUGUI contentField;
  public LayoutElement layoutElement;
  public int characterWrapLimit;
  RectTransform rectTransform;
  void Awake() {
    rectTransform = GetComponent<RectTransform>();
  }

  void Update() {

    //transform.position = position;
    FollowMouse();
  }

  void FollowMouse() {

    Vector2 position = Input.mousePosition;
    float pivotX = (position.x / Screen.width);
    float pivotY = (position.y / Screen.height);
    rectTransform.pivot = new Vector2(pivotX, pivotY);
    transform.position = position;
  }

  public void SetText(string content, string header = "") {
    if (string.IsNullOrEmpty(header)) {
      headerField.gameObject.SetActive(false);
    } else {
      FollowMouse();
      headerField.gameObject.SetActive(true);
      headerField.text = header;
    }
    if (string.IsNullOrEmpty(content)) {
      contentField.gameObject.SetActive(false);
    } else {
      FollowMouse();
      contentField.gameObject.SetActive(true);
      contentField.text = content;
    }
    contentField.text = content;
    if (Application.isEditor) {
      int headerLength = headerField.text.Length;
      int contentLength = contentField.text.Length;

      layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
    }
  }
}