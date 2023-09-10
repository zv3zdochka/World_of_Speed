using UnityEngine;

public class Shoper : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0f, rotation, 0f);

        Vector3 forwardMovement = transform.forward * verticalInput * speed * Time.deltaTime;

        Vector3 newPosition = transform.position + forwardMovement;
        newPosition.y = transform.position.y;

        transform.position = newPosition;
    }
}