using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private List<ItemData> _items = new List<ItemData>();

    public List<ItemData> Items => _items;

    private void Start()
    {
        _items = GenerateItems();
    }

    private List<ItemData> GenerateItems()
    {
        ReturnSpot[] returnSpots = FindObjectsOfType<ReturnSpot>();
        List<ItemData> items = new List<ItemData>();
        foreach (ReturnSpot returnSpot in returnSpots) 
        {
            items.Add(returnSpot.ItemToReturn);
        }
        return items;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_items.Count > 0)
        {
            if(collision.TryGetComponent<Inventory>(out var inventory))
            {
                inventory.PickupItem(_items.First());
                _items.Remove(_items.First());
            }
        }
    }
}
