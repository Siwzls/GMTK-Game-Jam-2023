using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemGiver : MonoBehaviour
{
    [SerializeField] private List<ItemData> _items;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Inventory>(out var inventory))
        {
            inventory.PickupItem(_items.First());
            _items.Remove(_items.First());
        }
    }
}
