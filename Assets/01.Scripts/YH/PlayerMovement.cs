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
    }

    private void FixedUpdate()
    {
        _rigid.MovePosition(transform.position + _dir * _speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && _isGround)
            _rigid.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
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

    private void OnDrawGizmos()
    {
        Gizmos.color = _rayColer;

        if (true == Physics.BoxCast(transform.position, transform.lossyScale / 2.0f, transform.forward, out RaycastHit hit, transform.rotation, _maxDistance,_dieLayer))
        {
            // Hit된 지점까지 ray를 그려준다.
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);

            // Hit된 지점에 박스를 그려준다.
            Gizmos.DrawWireCube(transform.position + transform.forward * hit.distance, transform.lossyScale);
        }
        else
        {
            // Hit가 되지 않았으면 최대 검출 거리로 ray를 그려준다.
            Gizmos.DrawRay(transform.position, transform.forward * _maxDistance);
        }
        
    }

    private void PlayerMove()
    {
        if (_pos == _nextPos)
        {
            _nextPos += _pos;

        }
    }
    
    
}
