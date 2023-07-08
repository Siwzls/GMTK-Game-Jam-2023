using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const int INTERACTION_DISTANCE = 1;
    [SerializeReference] private KeyCode _interactionKey;
    [SerializeField] private float _speed = 5f;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    private float _input;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        GatherInput();
    }

    private void FixedUpdate()
    {
        Movement();
    }
    private void GatherInput()
    {
        _input = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(_interactionKey))
        {
            Interact();
        }
    }

    private void Interact()
    {
        Collider2D[] points = Physics2D.OverlapBoxAll(transform.position, new Vector2(INTERACTION_DISTANCE, 1), 0);
        if (points != null)
        {
            foreach(var point in points)
            {
                if (point.TryGetComponent<IInteractable>(out var interactable))
                {
                    interactable.Interact(gameObject);
                }
            }
        }
    }

    private void Movement()
    {
        Vector2 velocity = new Vector2(_speed * _input, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = velocity;

        if (_input == 1)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_input == -1)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
