using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take : MonoBehaviour
{
    float distance = 100f;
    public Transform pos;
    private Rigidbody rb;
   
    
    void Start()
    {
        rb =  GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        
    }

    void OnMouseDown(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray,distance))
        {
            GetComponent<BoxCollider>().enabled=false;
            rb.MovePosition(pos.position);
            rb.isKinematic = true;
            Debug.Log("meow");
            
        }
    }
}
