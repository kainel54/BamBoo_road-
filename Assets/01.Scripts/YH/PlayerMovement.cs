using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody _rigid;
    private CharacterController _characterController;
    float _moveSpeed = 5f;
    float _gravity = -9.8f;
    float _yVelocity = 0f;
    float _jumpPower = 5f;

    [SerializeField] private LayerMask _layerMask;
    private bool _isGround;

    Vector3 _moveDir = Vector3.zero;


    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovementHandle();
        Jump();
    }

    private void Jump()
    {
        if (IsGround() && Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 jumpUp = Vector3.up * _jumpPower;
            _rigid.AddForce(jumpUp, ForceMode.VelocityChange);
        }
    }

    private void MovementHandle()
    {
        if (_characterController == null) return;
        _moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        _moveDir = _characterController.transform.TransformDirection(_moveDir);
        _moveDir *= _moveSpeed;
    }


    private bool IsGround()
    {
        _isGround = Physics.Raycast(transform.position, Vector3.down, 1.1f, _layerMask);
        return _isGround;
    }
}
