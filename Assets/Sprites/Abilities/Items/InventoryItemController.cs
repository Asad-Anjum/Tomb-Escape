using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    Item item;

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }


    public void AddItem(Item newItem)
    {

        item = newItem;
    }

    public void UseItem()
    {
        switch (item.itemType)
        {
            case Item.ItemType.ffd:
                CharacterController.Instance.FastForward();
                break;
            case Item.ItemType.bwd:
                CharacterController.Instance.Rewind();
                break;
            case Item.ItemType.enrage:
                CharacterController.Instance.Enrage();
                break;
            case Item.ItemType.trap:
                CharacterController.Instance.Trap();
                break;
            case Item.ItemType.map:
                CharacterController.Instance.Map();
                break;
            case Item.ItemType.marker:
                CharacterController.Instance.Marker();
                break;
            case Item.ItemType.brighter:
                CharacterController.Instance.Brighter();
                break;
            case Item.ItemType.burnOut:
                CharacterController.Instance.BurnOut();
                break;
        }
        RemoveItem();
    }

    
}
