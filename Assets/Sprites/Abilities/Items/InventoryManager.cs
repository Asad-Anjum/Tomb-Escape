 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public InventoryItemController[] InventoryItems;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
        ListItems();
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
        ListItems();
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        for(int i = Items.Count - 1; i >= 0; i--)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemIcon = obj.transform.Find("Image").GetComponent<Image>();

            itemIcon.sprite = Items[i].icon;

        }



        SetInventoryItems();
    }

    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for(int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }
}
