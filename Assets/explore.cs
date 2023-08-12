using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explore : MonoBehaviour
{
    public float delay = 0.05f;
    public float direction = 90f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0,0,direction);
        Destroy(this.gameObject, delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
