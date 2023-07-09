using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarExit : MonoBehaviour
{
    private const string CAR_LEAVE_ANIMATION = "CarLeave";

    [SerializeField] private BoxCollider2D _itemSpawnerTrigger;
    [SerializeField] private BoxCollider2D _exitTrigger;

    private Animator _animator;

    private bool _isActive = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        TaskHandler.AllTasksCompleted += OnTasksComplete;
    }

    private void OnTasksComplete()
    {
        _itemSpawnerTrigger.enabled = false;
        _exitTrigger.enabled = true;
        _isActive = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_isActive)
        {
            _animator.Play(CAR_LEAVE_ANIMATION);
            collision.gameObject.SetActive(false);
        }
    }
}
