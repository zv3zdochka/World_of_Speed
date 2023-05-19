
using UnityEngine;

public class StartFinishScript : MonoBehaviour
{
    public TimerScript timer;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("start"))
        {
            timer.StartTimer();
        }
        else if (other.gameObject.CompareTag("portal"))
        {
            timer.StopTimer();
               
        }
    }   
}