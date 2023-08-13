using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    [SerializeField] private Image uiImage;
    public Sprite spriteObject; // Reference to the GameObject with the sprite
    public Transform CameraPoint;

    private void Update()
    {
        // Get the sprite renderer from the 2D object
        Vector3 camPos = Camera.main.transform.position;
        Vector3 childCamPos = CameraPoint.position;
        if (camPos == childCamPos)
        {
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

