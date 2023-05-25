using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    [SerializeField]
    private Texture2D[] textures;

    private Renderer carRenderer;

    private void Start()
    {
        carRenderer = GetComponent<Renderer>();

        int savedTextureIndex = PlayerPrefs.GetInt("CarTextureIndex", -1);

        if (savedTextureIndex >= 0 && savedTextureIndex < textures.Length)
        {
            carRenderer.material.mainTexture = textures[savedTextureIndex];
        }
        else
        {

            PlayerPrefs.SetInt("CarTextureIndex", 0);
            PlayerPrefs.Save();

            carRenderer.material.mainTexture = textures[0];
        }
    }
}