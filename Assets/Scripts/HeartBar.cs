using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBar : MonoBehaviour
{
    public Sprite One, Two, Three, Four, Five, Six;
    
    Image barImage;
    private void Awake()
    {
        barImage = GetComponent<Image>();
    }

    public void SetHeartImage(int status)
    {
        switch (status)
        {
            case 1:
                barImage.sprite = One;
                break;
            case 2:
                barImage.sprite = Two;
                break;
            case 3:
                barImage.sprite = Three;
                break;
            case 4:
                barImage.sprite = Four;
                break;
            case 5:
                barImage.sprite = Five;
                break;
            case 6:
                barImage.sprite = Six;
                break;
        }
    }
}

