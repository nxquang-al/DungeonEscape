using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    public Image uiImage;
    public Sprite spriteObject; // Reference to the GameObject with the sprite
    public Transform CameraPoint;
    public GameObject groupActive;
    public GameObject groupDisabled;


    private void Update()
    {
        // Get the sprite renderer from the 2D object
        Vector3 camPos = Camera.main.transform.position;
        Vector3 childCamPos = CameraPoint.position;
        if (camPos == childCamPos)
        {
            groupActive.SetActive(true);
            groupDisabled.SetActive(false);
            if (spriteObject != null)
            {
                // Assign the sprite from the sprite renderer to the UI Image component
                uiImage.sprite = spriteObject;

            }
            else
            {
                Debug.LogWarning("SpriteRenderer not found on the 2D object.");
            }
        }
        
    }
}

