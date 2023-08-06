using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizzadShot : Enemy
{
    public GameObject bullet;
    public GameObject bulletParent;
    public float fireRate = 1f;
    private float nextFireTime;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()


    {
        if (nextFireTime < Time.time){


            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time+ fireRate;
        }
    }
}
