using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseSlot : MonoBehaviour
{
    void Update(){
      transform.position = Input.mousePosition;
    }
    public StorableItem currentItem;
    public int itemCount;
    public Image icon;
    public TextMeshProUGUI itemCountText;
}
