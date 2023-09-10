using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBounce : MonoBehaviour
{
    public float bounceSpeed = 8;
    public float bounceAmplitude = 0.05f;
    public float rotationSpeed = 90;

    private float startHeight;
    private float timeOffset;

    
    void Start()
    {
        startHeight = transform.localPosition.y;
        timeOffset = Random.value * Mathf.PI * 2;
    }

    
    void Update()
    {
        
        float finalheight = startHeight + Mathf.Sin(Time.time * bounceSpeed + timeOffset) * bounceAmplitude;
        var position = transform.localPosition;
        position.y = finalheight;
        transform.localPosition = position;

        
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotation.y += rotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        
    }
}
