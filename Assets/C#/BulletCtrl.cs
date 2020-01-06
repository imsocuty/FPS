using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 1000.0f;
    

    void Start()
    {
        
        GetComponent<Rigidbody>().AddForce(transform.up * speed);
    }

 
}
