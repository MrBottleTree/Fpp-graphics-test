using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float
        _speed = 6f,
        _jumpTime = 15,
        _gravity = 11f,
        _jumpHeight = 5f,
        _sensitivityX = 1;
    private float _ogSpeed;
    private float jumpSpeed = 1f;
    private bool
        _jump = false,
        _reachedJumpPoint = false;
    [SerializeField]
    private Transform _jumpPoint;
    private CharacterController _controller;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _ogSpeed = _speed;
    }

    void Update()
    {
        float _mouseX = Input.GetAxis("Mouse X");
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += _mouseX * _sensitivityX;
        transform.localEulerAngles = newRotation;
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.transform.TransformDirection(moveDirection);
        moveDirection *= _speed;
        if (_controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                StartCoroutine(jumpRoutine());
            }
        }
 
        else
        {
            moveDirection.y -= _gravity;
        }
        _controller.Move(moveDirection * Time.deltaTime);
    }
    IEnumerator jumpRoutine()
    {
        _gravity *= -1;
        yield return new WaitForSeconds(0.2f);
        _gravity *= -1;
    }
}