using System;
using System.IO;
using UnityEngine;
using System.Collections;


public class Move : MonoBehaviour
{
    public float speed = 0f; 
    public float maxSpeed = 50f; 
    public float sideSpeed = 0f; 
    public float rotateSpeed = 50f; 
    public int coins = 0;
    public float acceleration = 0.03f; 
    public float deceleration = 0.06f; 

    public float liftedObjectHeight = 2f; 
    public float liftedObjectDuration = 2f; 

    void Update()
    {
        float moveSide = Input.GetAxis("Horizontal");
        float moveForward = Input.GetAxis("Vertical");
        float rotation = moveSide * rotateSpeed;

        if (moveForward > 0)
        {
            if (speed >= 0)
                speed += acceleration * moveForward;
            else
                speed += deceleration * moveForward;
        }
        else if (moveForward < 0)
        {
            if (speed <= 0)
                speed += acceleration * moveForward;
            else
                speed += deceleration * moveForward;
        }
        else
        {
            if (speed > 0)
            {
                speed -= deceleration;
                if (speed < 0)
                    speed = 0;
            }
            else if (speed < 0)
            {
                speed += deceleration;
                if (speed > 0)
                    speed = 0;
            }
        }

        if (Mathf.Abs(speed) > maxSpeed)
        {
            speed = Mathf.Sign(speed) * maxSpeed;
        }

        MoveCar(rotation);
    }


    void MoveCar(float rotation)
    {
        transform.Rotate(0, rotation * Time.deltaTime, 0);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    

    
}
