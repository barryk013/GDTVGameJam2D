using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public Item Item { get; private set; }
    public void PickUp(Item newItem)
    {
        if (Item != null)
            DropItem(newItem.transform.position);

        this.Item = newItem;
        Item.gameObject.SetActive(false);
    }
    private void DropItem(Vector3 dropLocation)
    {
        Item.transform.position = dropLocation;
        Item.gameObject.SetActive(true);
    }
}
