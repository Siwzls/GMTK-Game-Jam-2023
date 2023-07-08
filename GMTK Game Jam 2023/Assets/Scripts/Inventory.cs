using UnityEngine;

public class Inventory : MonoBehaviour
{
    private ItemData _currentCarryingItem;

    public ItemData CurrentCarryingItem => _currentCarryingItem;

    public void PickupItem(ItemData item)
    {
        _currentCarryingItem = item;
    }
    public void PutItem()
    {
        _currentCarryingItem = null;
    }
}
