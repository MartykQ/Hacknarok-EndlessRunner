using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CameraMotor : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 offset;
    private Vector3 moveVector;
    private float transition = 0.0f;
    private float animDur = 2.0f;
    private Vector3 animationOffset = new Vector3(0,5,3);
    
    // Start is called before the first frame update
    void Start()
    {
       lookAt= GameObject.FindGameObjectWithTag("Player").transform;
       offset = transform.position - lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = lookAt.position + offset;
        
        moveVector.x = 0;
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);

        if (transition > 1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime / animDur;
            transform.LookAt(lookAt.position+Vector3.up);
        }
    }
}
