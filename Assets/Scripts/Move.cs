using System;
using System.IO;
using UnityEngine;

public class Move : MonoBehaviour
{

    public float speed = 0f; //Скорость
    public float maxSpeed = 50f; //Максимальная скорость
    public float sideSpeed = 0f; //Боковая скорость
    public float rotateSpeed = 50f; //Скорость поворота

    public float scores = 0f; 
    public float highScore = 0f; 


    void Update()    
    {
        float moveSide = Input.GetAxis("Horizontal"); 
        float moveForward = Input.GetAxis("Vertical"); 
        float rotation = moveSide * rotateSpeed; 

        if (moveForward != 0)
        {
            speed += 0.01f * moveForward; 
        }
        else 
        {
            if (speed > 0)
            {
                speed -= 0.01f;
            }
            else
            {
                speed += 0.01f;
            }
        }

        if (speed > maxSpeed)
        {
            speed = maxSpeed; 
        }

        MoveCar(rotation);
    }

    void MoveCar(float rotation)
    {
        transform.Rotate(0, rotation * Time.deltaTime, 0); 
        transform.Translate(Vector3.forward * speed * Time.deltaTime); 
    }

}