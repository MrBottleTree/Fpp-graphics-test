using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseY : MonoBehaviour
{
    [SerializeField]
    private float _sensitivityY = 1;
    void Update()
    {
        float _mouseY = Input.GetAxis("Mouse Y") * -1;
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x += _mouseY * _sensitivityY;
        transform.localEulerAngles = newRotation;
    }
}
