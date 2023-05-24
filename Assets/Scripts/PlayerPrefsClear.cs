using UnityEngine;

public class PlayerPrefsClear : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs have been cleared.");
    }
}