using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class PlayerHeart : MonoBehaviour
{
    // Start is called before the first frame update
    //public static event Action OnPlayerDamaged;
    //public static event Action OnPlayerDeath;
    //public static event Action OnPlayerGained;
    private HeartBar heartBar;
    private int currentHeart, maxHeart;
    void Start()
    {
        currentHeart = 3;
        maxHeart = 6;
        GameObject heartBarObject = GameObject.Find("HeartBar");
        if (heartBarObject != null)
        {
            heartBar = heartBarObject.GetComponent<HeartBar>();
            heartBar.SetHeartImage(currentHeart);
        }
        else
        {
            Debug.LogError("HeartBar object not found or does not have HeartBar component.");
        }
    }

    public void GainHeart()
    {
        currentHeart = Math.Min(currentHeart + 1, maxHeart);
        heartBar.SetHeartImage(currentHeart);
    }

    public void TakeDamage()
    {
        currentHeart -= 1;
        if (currentHeart > 0)
        {
            heartBar.SetHeartImage(currentHeart);
        }
    }
}
