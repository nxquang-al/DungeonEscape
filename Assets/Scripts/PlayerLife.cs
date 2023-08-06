using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    public bool isAlive = true;

    [SerializeField] private float smallJumpForce = 7f;


    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }


    private void Die(){
        isAlive = false;
        anim.SetTrigger("death");
        rb.velocity = new Vector2(rb.velocity.x, smallJumpForce);
        coll.isTrigger = true;
    }
}
