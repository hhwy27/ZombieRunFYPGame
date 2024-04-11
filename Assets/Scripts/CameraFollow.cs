using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; //moves the camera as its the "target"

    Vector3 difference; //keeps note of the difference between ball and camera

    // Start is called before the first frame update
    void Start()
    {
        difference = target.position - transform.position; //distance between our target position and camera's position

    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void FixedUpdate()
    {
        //make the camera always follow the ball within the "difference" distance
        transform.position = target.position - difference;
    }

    
}
