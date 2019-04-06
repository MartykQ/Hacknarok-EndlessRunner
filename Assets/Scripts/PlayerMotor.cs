using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;

    private float velocity = 5;
    private float verticalVelocity = 0;
    private float gravity=2.0f;


    private Vector3 moveVector;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (controller.isGrounded)
        {
            verticalVelocity = 0;
        }
        else
        {
            verticalVelocity -=gravity;
        }

        moveVector = Vector3.zero;
        moveVector.z = velocity;
        moveVector.y = verticalVelocity;
        moveVector.x=Input.GetAxisRaw("Horizontal");
        
        controller.Move(moveVector * Time.deltaTime);
    }
}
