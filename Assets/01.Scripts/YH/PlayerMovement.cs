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
    [SerializeField] LayerMask _jumpLayer;
    [SerializeField] LayerMask _dieLayer;
    bool _isGround;
        [SerializeField] private Color _rayColer;
    private float _maxDistance = 2f;

    private Vector3 _dir = Vector3.zero;
    float _pos;
    float _nextPos = 2.5f;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _dir.x = Input.GetAxisRaw("Horizontal");
        _dir.z = Input.GetAxisRaw("Vertical");
        _dir = _dir.normalized;
        _pos = _dir.z;

        GroundCheak();
        PlayerMove();
        HitCheck();
        Debug.Log(_isGround);
    }

    private void FixedUpdate()
    {
        _rigid.velocity = _dir * _speed;

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            //transform.position += new Vector3(0, Mathf.Lerp(0, 4, 3f), 0);
            _rigid.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        }
    }

    private void GroundCheak()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + (Vector3.down * 1f), Vector3.down, out hit, 0.4f, _jumpLayer))
        {
            _isGround = true;
        }

        else
        {
            _isGround = false;
        }
    }

    private void HitCheck()
    {
        if(Physics.BoxCast(transform.position, transform.lossyScale / 2.0f, transform.forward, out RaycastHit hit, transform.rotation, _maxDistance, _dieLayer))
        {
            Debug.Log("hit");
        }
    }

    private void PlayerMove()
    {
        if (_pos == _nextPos)
        {
            _nextPos += _pos;
            GameManager.instance.ScorePlus();
        }
    }
    
    
}
