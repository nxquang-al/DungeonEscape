using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private GameObject hitEffect; 
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        rb.velocity = transform.right * speed;
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")){
            GameObject obj = Instantiate(hitEffect, transform.position, transform.rotation);
            anim = obj.GetComponent<Animator>();
            anim.SetTrigger("hitEnemy");
            DeactivateObject();
        }
        else if(other.CompareTag("Ladder") || other.CompareTag("Ground")){
            GameObject obj = Instantiate(hitEffect, transform.position, transform.rotation);
            anim = obj.GetComponent<Animator>();
            anim.SetTrigger("hitWall");
            DeactivateObject();
        }
        else{
            Invoke("DeactivateObject", 1f);
        }
    }

    void DeactivateObject(){
        Destroy(gameObject);
    }
}
