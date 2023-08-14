using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator anim;
    private bool isHit = false;
    public bool destroyDoorOnHit = false;


    public GameObject[] doors;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    public void Hit(){
        isHit = true;
        anim.SetTrigger("hit");
        SoundManager.PlaySound("hit01");
        for (int i = 0; i < doors.Length; i++)
        {
            if(doors[i] != null){
                doors[i].GetComponent<Door>().Open();
                if(destroyDoorOnHit){
                    doors[i].GetComponent<Door>().DeactivateObject();
                    doors[i] = null;
                }
            }
        }
    }   
}
