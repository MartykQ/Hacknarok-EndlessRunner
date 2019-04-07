using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;


    public State state;
    
    private float getVelocity()
    {
        return 4 + 2f * (Time.time/6.0f);
    }


    private float verticalVelocity = 0;
    private float gravity=2.0f;
    private float animDur = 2.0f;



    private Vector3 moveVector;

    private float last_point_dist = 0.0f;
    private float dist_per_point = 3.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

//        if (Time.time < animDur)
//        {
//            moveVector = Vector3.zero;
//            moveVector.z = velocity;
//            controller.Move(moveVector * Time.deltaTime);
//            return;
//        }
//        
        if(state.isDead)
            return; //todo: death logic

        getPoints();
        
        if (controller.isGrounded)
        {
            verticalVelocity = 0;
        }
        else
        {
            verticalVelocity -=gravity;
        }

        moveVector = Vector3.zero;
        moveVector.z = getVelocity();
        moveVector.y = verticalVelocity;
        moveVector.x=5.0f*Input.GetAxisRaw("Horizontal");
        
        controller.Move(moveVector * Time.deltaTime);
    }

    void getPoints()
    {
        if (controller.transform.position.z - last_point_dist > dist_per_point)
        {
            state.score += 1;
            last_point_dist = controller.transform.position.z;
        }
    }

    void OnControllerColliderHit (ControllerColliderHit info)
    {
        Debug.Log(info.collider.tag);
        switch (info.collider.tag)
        {
            case "OBS":
                state.isDead = true;
            break;
        }

    }
}
