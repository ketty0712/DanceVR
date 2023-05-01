using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// This script is used to fade in and out between scenes
public class SceneFadeInOut : MonoBehaviour
{
    // Start is called before the first frame update
    public float fadeSpeed = 1.5f;      // Speed that the screen fades to and from black.
    public bool sceneStarting = true;   // Whether or not the scene is still fading in.
    private RawImage rawImage;


    void Awake()
    {
        rawImage = GetComponent<RawImage>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sceneStarting)
        {
            StartScene();
        }
    }

    private void FadeToClear()
    {
        // Lerp the colour of the texture between itself and transparent.
        rawImage.color = Color.Lerp(rawImage.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    private void FadeToBlack()
    {
        // Lerp the colour of the texture between itself and black.
        rawImage.color = Color.Lerp(rawImage.color, Color.black, fadeSpeed * Time.deltaTime);
    }

    void StartScene()
    {
        // Fade the texture to clear.
        FadeToClear();

        // If the texture is almost clear...
        if(rawImage.color.a <= 0.05f)
        {
            // ... set the colour to clear and disable the RawImage.
            rawImage.color = Color.clear;
            rawImage.enabled = false;

            // The scene is no longer starting.
            sceneStarting = false;
        }
    }

    public void EndScene()
    {
        // Make sure the RawImage is enabled.
        rawImage.enabled = true;

        // Start fading towards black.
        FadeToBlack();

        // If the screen is almost black...
        if(rawImage.color.a >= 0.95f)
        {
            // ... reload the level.
            SceneManager.LoadScene(0);
        }
    }
}
