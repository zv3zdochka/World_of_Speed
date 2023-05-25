using UnityEngine;

public class PlayerPrefsClear : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
        
        //var currentSceneName = "LEVEL_";

        //for (var i = 1; i <= 5; i++) {
        //    var sceneNameWithNumber = currentSceneName + i;
        //    PlayerPrefs.SetInt(sceneNameWithNumber, 3);
        //}

    }
}