using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ItemPlace : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemData _itemToPlace;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _spriteRenderer.enabled = false;
    }

    public void Interact(GameObject player)
    {
        var inventory = player.GetComponent<Inventory>();
        if (inventory.CurrentCarryingItem == _itemToPlace)
        {
            _spriteRenderer.enabled = true;
            _spriteRenderer.sprite = inventory.CurrentCarryingItem.Sprite;
            inventory.PutItem();
        }
    }
}
