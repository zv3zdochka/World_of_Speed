using UnityEngine;

public class Shoper : MonoBehaviour
{
    public float speed = 5f; // Movement speed of the shoper
    public float rotationSpeed = 100f; // Rotation speed of the shoper

    void Update()
    {
        // Get input from the horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate rotation based on horizontal input
        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0f, rotation, 0f);

        // Calculate forward movement based on vertical input
        Vector3 forwardMovement = transform.forward * verticalInput * speed * Time.deltaTime;

        // Calculate the new position by adding the forward movement vector to the current position
        Vector3 newPosition = transform.position + forwardMovement;
        newPosition.y = transform.position.y; // Maintain the same height (y-axis)

        // Update the position of the shoper to the new position
        transform.position = newPosition;
    }
}