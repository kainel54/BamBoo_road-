using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigid;
    [SerializeField] Transform _mainCam;
    [SerializeField] float _speed = 5f;
    [SerializeField] float _jumpPower = 10f;
    [SerializeField] float _rotSpeed = 1f;
    [SerializeField] LayerMask _layer;
    bool _isGround;


    private Vector3 dir = Vector3.zero;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.z = Input.GetAxisRaw("Vertical");
        dir = dir.normalized;

        GroundCheak();
    }

    private void FixedUpdate()
    {
        if (dir != Vector3.zero)
            transform.forward = Vector3.Lerp(transform.forward, dir, _speed * Time.deltaTime);

        _rigid.MovePosition(transform.position + dir * _speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump")&&_isGround)
            _rigid.AddForce(Vector3.up*_jumpPower, ForceMode.Impulse);
    }

    private void GroundCheak()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + (Vector3.down * 1f), Vector3.down, out hit, 0.4f, _layer))
        {
            _isGround = true;
        }

        else
        {
            _isGround= false;
        }
    }
}
