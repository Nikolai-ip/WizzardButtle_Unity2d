using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateElement : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    void FixedUpdate()
    {
        transform.Rotate(0, 0, _rotateSpeed);
    }
}
