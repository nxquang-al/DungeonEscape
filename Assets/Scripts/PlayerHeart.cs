using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHeart : MonoBehaviour
{
    // Start is called before the first frame update
    //public static event Action OnPlayerDamaged;
    //public static event Action OnPlayerDeath;
    //public static event Action OnPlayerGained;
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private float smallJumpForce;

    private HeartBar heartBar;
    private int currentHeart, maxHeart;

    [HideInInspector]
    public bool isAlive = true;

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

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        smallJumpForce = GetComponent<PlayerMovement>().smallJumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAlive && collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (isAlive && collider.CompareTag("Trap"))
        {
            TakeDamage();
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
        Die();
    }
    private void Die()
    {
        isAlive = false;
        rb.velocity = new Vector2(rb.velocity.x, smallJumpForce);
        coll.isTrigger = true;
    }

    private void RestartOrReplay()
    {
        if (currentHeart > 0)
        {
            Replay();
        }
        else
        {
            LoadLoseScene();
        }
    }

    private void Replay()
    {
        isAlive = true;
        coll.isTrigger = false;
        transform.position = GetComponent<PlayerMovement>().reloadPosition;
    }
    private void LoadLoseScene()
    {
        SceneManager.LoadScene(5);
    }
}
