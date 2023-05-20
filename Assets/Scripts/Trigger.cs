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
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Bo_up"))
            {
                Move player = GameObject.FindWithTag("Player").GetComponent<Move>();
                player.speed += player.acceleration * 5;
                
            }
            else if (other.CompareTag("Bo_down"))
            {
                Move player = GameObject.FindWithTag("Player").GetComponent<Move>();
                player.speed -= player.acceleration * 10;
                
            }
            else if (other.CompareTag("Coin"))
            {
                Move player = GameObject.FindWithTag("Player").GetComponent<Move>();
                player.coins += 1;

            }
            Destroy(gameObject);
            
        }
    }
    
    
    
}
