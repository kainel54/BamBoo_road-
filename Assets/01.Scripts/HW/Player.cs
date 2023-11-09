using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 5;
    private float pos;
    private float nextpos = 2.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        PlayerMoveScore();

        if(Input.GetKeyDown(KeyCode.H))
        {
            GameManager.instance.GameOver();
        }
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        rb.velocity = (transform.forward * z + transform.right * x).normalized 
            * speed + Vector3.up * rb.velocity.y;

        pos = transform.position.z;
    }

    void PlayerMoveScore()
    {
        if(pos > nextpos)
        {
            nextpos += 2.5f;
            GameManager.instance.ScorePlus();
        }
    }


}
