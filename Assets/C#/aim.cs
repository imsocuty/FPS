using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class aim : MonoBehaviour {
 
    private Vector3 ScreenCenter;
 
    // Use this for initialization
    void Start () {
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
    }
    
    // Update is called once per frame
    void Update () {
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
    }
}
