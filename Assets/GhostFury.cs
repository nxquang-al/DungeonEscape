using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFury : Enemy
{
    public float speed;
    private Transform player;
    public float timeToToggle = 2;
    public float deltaTime = 2;
    public float currentTime = 0;
    public GameObject startPoint;
    public float rangeToActive = 5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = startPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer <= rangeToActive) {
            currentTime += Time.deltaTime;
            if (currentTime > timeToToggle)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed*Time.deltaTime);
            }
            if (currentTime > timeToToggle + deltaTime) {
                currentTime = 0;
            }
        }
        else {
            transform.position = startPoint.transform.position;
        }
    }

     void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(transform.position, rangeToActive);
    }
}
