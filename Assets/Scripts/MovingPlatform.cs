using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    Vector3 targetPos;
    [SerializeField] GameObject ways;
    [SerializeField] Transform[] wayPoints;
    [SerializeField] bool isContinous = false;

    [HideInInspector]
    public bool isMoving = false;

    private int pointIndex;
    private int pointCount;
    private int direction = 1;

    private void Awake(){
        wayPoints = new Transform[ways.transform.childCount];
        for (int i = 0; i < ways.gameObject.transform.childCount; i++)
        {
            wayPoints[i] = ways.transform.GetChild(i).gameObject.transform;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pointCount = wayPoints.Length;
        pointIndex = 1;
        targetPos = wayPoints[pointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving){
            Move();
        }
    }

    private void Move(){
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        if (transform.position == targetPos){
            // NextPoint();
            isMoving = false;
        }
    }

    private void NextPoint(){
        if (pointIndex == pointCount - 1)
        {
            direction = -1;
        }
        if (pointIndex == 0){
            direction = 1;
        }

        pointIndex += direction;
        targetPos = wayPoints[pointIndex].transform.position;
    }
}
