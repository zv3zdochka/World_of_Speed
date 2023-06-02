using UnityEngine;

public class Trigger : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // No code inside Update() for this script
    }

    // OnTriggerEnter is called when another collider enters this trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Check if the trigger object has the tag "Bo_up"
            if (gameObject.CompareTag("Bo_up"))
            {
                // Get the Move component attached to the player object
                Move player = GameObject.FindWithTag("Player").GetComponent<Move>();
                // Increase the player's speed by the acceleration multiplied by 5
                player.speed += player.acceleration * 5;
            }
            // Check if the collided object has the tag "Bo_down"
            else if (other.CompareTag("Bo_down"))
            {
                // Get the Move component attached to the player object
                Move player = GameObject.FindWithTag("Player").GetComponent<Move>();
                // Decrease the player's speed by the acceleration multiplied by 10
                player.speed -= player.acceleration * 10;
            }
            // Check if the collided object has the tag "Coin"
            else if (other.CompareTag("Coin"))
            {
                // Get the Move component attached to the player object
                Move player = GameObject.FindWithTag("Player").GetComponent<Move>();
                // Increase the player's coin count by 1
                player.coins += 1;
            }

            // Destroy the trigger object
            Destroy(gameObject);
        }
    }
}