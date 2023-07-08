using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HidingSpot : MonoBehaviour, IInteractable
{
    private GameObject _hidingPlayer;
    public void Interact(GameObject player)
    {
        _hidingPlayer = player;
        player.SetActive(false);
        player.transform.position = new Vector2(transform.position.x, player.transform.position.y);
    }

    private void Update()
    {
        if (_hidingPlayer != null && Input.GetKeyDown(KeyCode.E))
        {
            Release();
        }
    }

    private void Release()
    {
        _hidingPlayer.SetActive(true);
        _hidingPlayer = null;
    }

}
