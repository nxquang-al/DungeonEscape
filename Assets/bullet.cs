using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    Rigidbody2D bulletRB;
    private Animator anim;
    [SerializeField] private GameObject hitEffect; 
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        bulletRB.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ladder") || other.CompareTag("Ground") || other.CompareTag("Player")){
            GameObject obj = Instantiate(hitEffect, transform.position, transform.rotation);
            if (other.CompareTag("Player")) {
                PlayerHeart player = other.GetComponent<PlayerHeart>();
                if (player != null) {
                    player.TakeDamage();
                }
            }
            Destroy(this.gameObject);
        }
    }
}