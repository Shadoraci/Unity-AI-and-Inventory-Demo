using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro; 

public class InventoryItemController : MonoBehaviour
{

    Item item;
    public TMP_Text QtyText;
    public Button RemoveButton;
    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);

        Destroy(gameObject);

        Debug.Log("Item Has Been Removed");
    }
    public void AddItem(Item newItem)
    {
        item  = newItem;
        Debug.Log("Added a new item");
        //item.Quantity++;
        QtyText.text = $"{item.Quantity}";
    }
    public void UseItem()
    {
        if(Input.GetKey(KeyCode.Mouse1)) 
        {
            Debug.Log("Trying to swtich");
            InventoryManager.Instance.SwitchHotBarInventory(item);
        }
        else
        {
            switch (item.itemType)
            {
                case Item.ItemType.Potion:
                    PlayerBehavior.Instance.IncreasedHealth(item.Value);
                    break;
                case Item.ItemType.DMR:
                    PlayerBehavior.Instance.ShootDMR(); 
                    break;
                case Item.ItemType.Pistol:
                    PlayerBehavior.Instance.ShootPistol();
                    break;
                case Item.ItemType.LMG:
                    PlayerBehavior.Instance.ShootLMG();
                    break;
                case Item.ItemType.Shotgun:
                    PlayerBehavior.Instance.ShootShotgun();
                    break;
                case Item.ItemType.Raygun:
                    PlayerBehavior.Instance.ShootRayGun();
                    break;
                case Item.ItemType.Nukegun:
                    PlayerBehavior.Instance.ShootNukeGun();
                    break;
                case Item.ItemType.Misc:
                    //knife prob
                    break;

            }
             item.Quantity -= 1; 
             Debug.Log($"{item.Quantity}");
             QtyText.text = $"{item.Quantity}";

            if (item.Quantity <= 0 )
            {
                RemoveItem(); 
            }
            
        }
    }
}
