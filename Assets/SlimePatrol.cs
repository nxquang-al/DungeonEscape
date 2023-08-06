using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public GameObject pointC;
    public GameObject pointD;
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
        // if (currentPoint == pointB.transform) {
        //     transform.Translate(Vector2.down * speed * Time.deltaTime);
        // }
        //  if (currentPoint == pointA.transform) {
        // }
        //  if (currentPoint == pointC.transform) {
        //     transform.Translate(Vector2.right * speed * Time.deltaTime);
        // }
        //   if (currentPoint == pointD.transform) {
        //     transform.Translate(Vector2.up * speed * Time.deltaTime);
        // }
            transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointA.transform){
            currentPoint = pointB.transform;
            transform.Rotate(0,0,90f);
        } 
         if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointB.transform){
            currentPoint = pointC.transform;
            transform.Rotate(0,0,90f);
        }   if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointC.transform){
            currentPoint = pointD.transform;
            transform.Rotate(0,0,90f);
        }   if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointD.transform){
            currentPoint = pointA.transform;
            transform.Rotate(0,0,90f);
        } 
    }
}