using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CameraMotor : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
       lookAt= GameObject.FindGameObjectWithTag("Player").transform;
       offset = transform.position - lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = lookAt.position + offset;
    }
}
