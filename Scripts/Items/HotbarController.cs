using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarController : MonoBehaviour
{
    public int HotbarSlotSize => gameObject.transform.childCount;
    private List<InventoryItemController> hotbarSlots = new List<InventoryItemController>();

    KeyCode[] hotbarKeys = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };
   
    
    private void Start()
    {
        SetHotBarSlot(); 
    }
    private void Update()
    {
        for(int i = 0; i < hotbarSlots.Count; i++)
        {
            if (Input.GetKeyDown(hotbarKeys[i]))
            {
                Debug.Log("Use Item: " + i);
                hotbarSlots[i].UseItem(); 
                return; 
            }
        }
    }
    private void SetHotBarSlot()
    {
        for(int i = 0; i < hotbarSlots.Count; i++)
        {
            InventoryItemController Slots = gameObject.transform.GetChild(i).GetComponent<InventoryItemController>();
            hotbarSlots.Add(Slots); 
        }
    }
}
