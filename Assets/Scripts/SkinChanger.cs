using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    [SerializeField]
    private Texture2D[] textures; // Array of textures for the car

    private Renderer carRenderer; // Reference to the Renderer component of the car

    private void Start()
    {
        carRenderer = GetComponent<Renderer>(); // Get the Renderer component attached to the same GameObject

        int savedTextureIndex = PlayerPrefs.GetInt("CarTextureIndex", -1); // Get the saved texture index from PlayerPrefs

        if (savedTextureIndex >= 0 && savedTextureIndex < textures.Length)
        {
            // If a valid saved texture index exists, set the car's mainTexture to the corresponding texture
            carRenderer.material.mainTexture = textures[savedTextureIndex];
        }
        else
        {
            // If no saved texture index or an invalid index exists, set it to 0, save it, and set the car's mainTexture to the first texture
            PlayerPrefs.SetInt("CarTextureIndex", 0);
            PlayerPrefs.Save();
            carRenderer.material.mainTexture = textures[0];
        }
    }
}