using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private Door _connectedDoor;

    public Door ConnectedDoor => _connectedDoor;

    private void Start()
    {
        if (_connectedDoor == null)
        {
            Debug.Log(gameObject.name + "don't have connected door");
        }
        if(_connectedDoor.ConnectedDoor == null)
        {
            _connectedDoor.SetDoor(this);
        }
    }

    private void SetDoor(Door door)
    {
        _connectedDoor = door;
    }

    public void Interact(GameObject player)
    {
        player.transform.position = _connectedDoor.transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if(_connectedDoor != null)
        {
            Gizmos.DrawLine(transform.position, _connectedDoor.transform.position);
        }
    }
}
