using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            PlayerHeart playerHeart = GetComponent<PlayerHeart>();
            if (playerHeart != null)
            {
                playerHeart.GainHeart();
                Destroy(collision.gameObject);
            }
            SoundManager.PlaySound("pickup");
        }
        else if (collision.gameObject.CompareTag("Gun"))
        {
            PlayerGun playerGun = GetComponent<PlayerGun>();
            if (playerGun != null)
            {
                playerGun.CollectGun();
                Destroy(collision.gameObject);
            }
            SoundManager.PlaySound("pickup");
        }
        else if (collision.gameObject.CompareTag("Energy"))
        {
            PlayerEnergy playerEnergy = GetComponent<PlayerEnergy>();
            if (playerEnergy != null)
            {
                playerEnergy.GainEnergy();
                Destroy(collision.gameObject);
            }
            SoundManager.PlaySound("pickup");
        }
    }
}
