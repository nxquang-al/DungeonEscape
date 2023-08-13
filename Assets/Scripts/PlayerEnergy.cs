using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerEnergy : MonoBehaviour
{
    // Start is called before the first frame update
    //public static event Action OnPlayerDamaged;
    //public static event Action OnPlayerDeath;
    //public static event Action OnPlayerGained;
    [HideInInspector]
    public int currentEnergy, maxEnergy;
    private TMP_Text text;

    void Start()
    {
        currentEnergy = 0;
        maxEnergy = 15;
        text = GameObject.Find("EnergyCounter").GetComponent<TextMeshProUGUI>();
        if (text != null)
        {
            text.text = printEnergy();
        }
        else
        {
            Debug.Log("Energy Null");
        }
    }
        private string printEnergy()
        {
            return "<sprite=3>" + currentEnergy + "/" + maxEnergy;
        }


    public void GainEnergy()
    {
        currentEnergy = Math.Min(currentEnergy+1, maxEnergy);
        if (text != null)
        {
            text.text = printEnergy();
        }
        else
        {
            Debug.Log("Energy Null");
        }
    }


    public void UseEnergy()
    {
        currentEnergy = Math.Max(currentEnergy, 0);
        text.text = "<sprite=3>x" + currentEnergy + "/" + maxEnergy;
    }
}
