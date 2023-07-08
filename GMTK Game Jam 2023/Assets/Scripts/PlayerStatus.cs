using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private bool _isHiding = false;
    private bool _canMove = true;

    public bool IsHiding => _isHiding;
    public bool CanMove => _canMove;
}
