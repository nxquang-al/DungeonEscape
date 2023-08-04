using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerGun : MonoBehaviour
{
    // Start is called before the first frame update
    //public static event Action OnPlayerDamaged;
    //public static event Action OnPlayerDeath;
    //public static event Action OnPlayerGained;
    public int currentGun;
    private TMP_Text text;

    void Start()
    {
        currentGun = 10;
        text = GameObject.Find("GunCounter").GetComponent<TextMeshProUGUI>();
        if (text != null)
        {
            text.text = printGun();
        }
        else
        {
            Debug.Log("Energy Null");
        }
    }
    private string printGun()
    {
        return "<sprite=2>" + currentGun;
    }


    public void CollectGun()
    {
        currentGun = currentGun+1;
        if (text != null)
        {
            text.text = printGun();
        }
        else
        {
            Debug.Log("Energy Null");
        }
    }


    public void Shot()
    {
        currentGun = Math.Max(currentGun-1, 0);
        text.text = printGun();
    }
}
