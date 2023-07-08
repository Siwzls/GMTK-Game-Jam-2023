using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StairsDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private StairsDoor _connectedDoor;

    public StairsDoor ConnectedDoor => _connectedDoor;

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

    private void SetDoor(StairsDoor door)
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
