using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarExit : MonoBehaviour
{
    [SerializeField] float _leaveSpeed = 10f;
    [SerializeField] private BoxCollider2D _itemSpawnerTrigger;
    [SerializeField] private BoxCollider2D _exitTrigger;

    private bool _isActive = false;
    private bool _canMove = false;

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

    private void Update()
    {
        if (_canMove)
        {
            CarLeave();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_isActive)
        {
            _canMove = true;
            collision.gameObject.SetActive(false);
        }
    }

    private void CarLeave()
    {
        Vector2 _targetPosition = new Vector2(transform.position.x - 10, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _leaveSpeed * Time.deltaTime);
    }
}
