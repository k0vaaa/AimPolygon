using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float range = 100f;
    public Camera cam;
   
    void Update()
    {   
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)){
            Debug.DrawRay(cam.transform.position, cam.transform.forward*100f, Color.red,1,false);
            Debug.Log(hit.transform.name);
        }
    }
}
