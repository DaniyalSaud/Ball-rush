using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovalScript : MonoBehaviour
{
    private Transform cam;
    
    void Awake()
    {
        cam = GameObject.Find("CameraHolder").transform;
            
    }
    private void Update()
    {
        if(cam){
            if(transform.position.z < cam.position.z - 8f)
            {
                Destroy(gameObject);
            }
        }
    }
}
