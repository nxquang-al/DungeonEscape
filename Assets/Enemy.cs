using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
   public void Die(){
        Destroy(this.gameObject, 0.1f);
    }
}