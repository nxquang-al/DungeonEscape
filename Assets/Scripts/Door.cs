using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;

    private BoxCollider2D coll;

    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        coll.isTrigger = false;
    }

    public void Open()
    {
        isOpen = true;
        coll.isTrigger = true;
    }
}
