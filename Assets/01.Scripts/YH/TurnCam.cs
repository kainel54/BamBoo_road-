using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCam : MonoBehaviour
{
    [SerializeField] private GameObject _stage;
    private float _xRotate;
    private float rotateSpeed = 50f;

    private void Update()
    {
        _xRotate = Vector3.right.x * Time.deltaTime*rotateSpeed;
        Vector3 stagePosition = _stage.transform.position;
        transform.RotateAround(stagePosition, Vector3.up, _xRotate);
        transform.LookAt(stagePosition);
    }
}
