using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

  public void UpdateSlotUI(ref Slot slot){
    if(slot.currentItem == null){
        slot.icon.sprite = null;
      }else{
        slot.icon.sprite = slot.currentItem.itemSprite;
        slot.itemCountText.text = slot.itemCount.ToString();
      }
  }
}
