using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed;
    public Vector3 move;
    public Rigidbody RB;
    void Start()
    {
        
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = -x * transform.right + -z * transform.forward;
        RB.velocity = Vector3.Lerp(RB.velocity, move * speed, speed);
    }
}
