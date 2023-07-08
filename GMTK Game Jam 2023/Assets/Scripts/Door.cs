using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;

    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    public void Interact(GameObject player)
    {
        ToggleDoor();
    }

    public void ToggleDoor()
    {
        _spriteRenderer.enabled = !_spriteRenderer.enabled;
        _boxCollider.enabled = !_boxCollider.enabled;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ToggleDoor();
    }
}
