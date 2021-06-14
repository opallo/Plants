using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MouseSlot : MonoBehaviour {
  [SerializeField] UIManager uiManager;
  public StorableItem currentItem;
  public int itemCount;
  public Image icon;
  public TextMeshProUGUI itemCountText;
  void Update() {
    transform.position = Input.mousePosition;
  }
  public void SubtractCurrentItem(int removeItemCount) {
    itemCount = Mathf.Max(itemCount - removeItemCount, 0);
    if(itemCount == 0){
      currentItem = null;
    }
  }
}