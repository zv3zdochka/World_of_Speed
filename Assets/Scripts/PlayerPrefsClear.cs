using UnityEngine;

public class PlayerPrefsClear : MonoBehaviour
{
    void Start()
    {
        // Clears all player preferences
        PlayerPrefs.DeleteAll();
        
    }
}