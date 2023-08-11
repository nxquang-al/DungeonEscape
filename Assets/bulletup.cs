using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletup : Enemy
{
    public GameObject pointA;
    public GameObject pointB;
    private Transform currentPoint;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        currentPoint = pointA.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPoint == pointB.transform) {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else {
            transform.Translate(Vector2.down * 2 * speed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointA.transform){
            currentPoint = pointB.transform;
        } 
         if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointB.transform){
            currentPoint = pointA.transform;
        } 
    }
}