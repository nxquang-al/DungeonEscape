using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator anim;
    private bool isHit = false;

    public GameObject[] columns;
    private MovingPlatform[] movingPlatforms;

    void Awake(){
        movingPlatforms = new MovingPlatform[columns.Length];
        for (int i = 0; i < columns.Length; i++)
        {
            movingPlatforms[i] = columns[i].GetComponent<MovingPlatform>();
        }   
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    public void Hit(){
        isHit = true;
        anim.SetTrigger("hit");
        for (int i = 0; i < movingPlatforms.Length; i++)
        {
            movingPlatforms[i].isMoving = true;
        }
    }   
}
