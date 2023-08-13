using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    private Animator anim;
    private Door door;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        door = GetComponent<Door>();
    }

    // Update is called once per frame
    void Update()
    {
        if (door.isOpen){
            anim.SetTrigger("off");
        }
    }
}
