using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ReturnSpot : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemData _itemToReturn;

    private SpriteRenderer _spriteRenderer;

    public Action<ItemData> ItemReturned;

    public ItemData ItemToReturn => _itemToReturn;

    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _spriteRenderer.enabled = false;
    }

    public void Interact(GameObject player)
    {
        var inventory = player.GetComponent<Inventory>();
        if (inventory.CurrentCarryingItem == _itemToReturn)
        {
            _spriteRenderer.enabled = true;
            _spriteRenderer.sprite = inventory.CurrentCarryingItem.Sprite;
            ItemReturned?.Invoke(inventory.CurrentCarryingItem);
            inventory.PutItem();
        }
    }
}
