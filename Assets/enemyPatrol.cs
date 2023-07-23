using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
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
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        Debug.Log(Vector2.Distance(transform.position ,currentPoint.position));
        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointA.transform){
            currentPoint = pointB.transform;
        } 
         if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointB.transform){
            currentPoint = pointA.transform;
        } 
    }
}
