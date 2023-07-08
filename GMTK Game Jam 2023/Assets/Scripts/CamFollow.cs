using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private float _lerpForce;

    private void LateUpdate()
    {
        Vector3 newVector = new Vector3(_target.position.x, _target.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, newVector, _lerpForce);
    }
}
