using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Rendering.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public List<Item> HotbarItems = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public UnityEngine.UI.Toggle EnableRemove;

    public InventoryItemController[] InventoryItems;

    public TMP_Text QtyText;

    public HotbarController hotbarcontroller;

    public void SwitchHotBarInventory(Item item)
    {
        foreach(Item i in Items)
        {
            if(i == item)
            {
                if(HotbarItems.Count <= 4)
                {
                    Debug.Log("Cannot add");
                }
                else
                {
                    HotbarItems.Add(item);
                    Items.Remove(item); 
                    //May need to make changes here
                }
            }
        }
        foreach(Item i in Items)
        {
            if(i == item)
            {
                HotbarItems.Remove(item);
                Items.Add(item);
                return; 
            }
        }
    }


    private void Awake()
    {
        Instance = this;
    }
    public void Add(Item item)
    {
        if (Items.Contains(item))
        {
            item.Quantity++;
            Debug.Log("Item is the same!" + item.Quantity);
        }
        else if (Items.Count <= 12)
        { 
            Items.Add(item);
            QtyText.text = $"Qty: {Items.Count}";
        }
        else
        {
            QtyText.text = $"HP: FULL"; 
        }
    }
    public void Remove(Item item)
    {
        if (Items.Contains(item))
        {
           Items.Remove(item);
        }
        else if (HotbarItems.Contains(item))
        {
            HotbarItems.Remove(item);
        }

        QtyText.text = $"Qty: {Items.Count}";
    }
    public void ListItems()
    {
        //Clean inventory
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
            QtyText.text = $"Qty: {Items.Count}";
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var ItemName = obj.transform.Find("ItemName").GetComponent<TMP_Text>();
            //var Qty = obj.transform.Find("Quantity").GetComponent<TMP_Text>();
            //var ItemIcon = obj.transform.Find("ItemIcon").GetComponent<UnityEngine.UI.Image>();
            var RemoveButton = obj.transform.Find("RemoveButton").gameObject;
            
            ItemName.text = item.ItemName;
            //Qty.text = item.Quantity; 
            //ItemIcon.sprite = item.Icon; 

            if (EnableRemove.isOn)
            {
                RemoveButton.SetActive(true); 
            }
        }

        SetInventoryItems(); 
    }

    public void EnableItemsRemove()
    {
        if (EnableRemove.isOn)
        {
            foreach(Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true); 
            }
        }
        else
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }

    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]); 
        }
    }
}
