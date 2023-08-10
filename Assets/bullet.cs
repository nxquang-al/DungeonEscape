using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    Rigidbody2D bulletRB;
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        bulletRB.velocity = new Vector2(speed *Time.deltaTime, 0);
        Destroy(this.gameObject,5);
    }

    // Update is called once per frame
    void Update()
    {
    }
}