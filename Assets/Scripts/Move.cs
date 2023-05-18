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
            speed += acceleration * moveForward;
        }
        else if (moveForward < 0)
        {
            if (speed > 0)
            {
                speed += deceleration * moveForward;
            }
            else
            {
                speed += acceleration * moveForward;
            }
        }
        else
        {
            if (speed > 0)
            {
                speed -= deceleration;
            }
            else if (speed < 0)
            {
                speed += deceleration;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bo_up"))
        {
            speed += acceleration * 5;
            LiftAndRemoveObject(other.gameObject);
        }
        else if (other.CompareTag("Bo_down"))
        {
            speed -= acceleration * 5;
            LiftAndRemoveObject(other.gameObject);
        }
    }

    void LiftAndRemoveObject(GameObject obj)
    {
        StartCoroutine(LiftAndRemoveRoutine(obj));
    }

    IEnumerator LiftAndRemoveRoutine(GameObject obj)
    {
        Vector3 originalPosition = obj.transform.position;
        Vector3 targetPosition = originalPosition + new Vector3(0f, liftedObjectHeight, 0f);

        float elapsedTime = 0f;
        while (elapsedTime < liftedObjectDuration)
        {
            float t = elapsedTime / liftedObjectDuration;
            obj.transform.position = Vector3.Lerp(originalPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(obj);
    }
}
