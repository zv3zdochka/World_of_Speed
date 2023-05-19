using System;
using System.IO;
using UnityEngine;
using System.Collections;


public class Move : MonoBehaviour
{
    public float speed = 0f; // Скорость
    public float maxSpeed = 50f; // Максимальная скорость
    public float sideSpeed = 0f; // Боковая скорость
    public float rotateSpeed = 50f; // Скорость поворота
    public int coins = 0;
    public float acceleration = 0.01f; // Ускорение
    public float deceleration = 0.02f; // Замедление

    public float liftedObjectHeight = 2f; // Высота поднятия объекта
    public float liftedObjectDuration = 2f; // Продолжительность поднятия объекта

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
