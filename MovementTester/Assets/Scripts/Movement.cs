using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Sens sens;
    public float sensX;
    public float sensY;


    public Transform orientation;
    float xRotation;
    float yRotation;


    void Start()
    {   
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        float mouseX = Time.fixedDeltaTime * Input.GetAxisRaw("Mouse X") * sens.x;
        float mouseY = Time.fixedDeltaTime * Input.GetAxisRaw("Mouse Y") * sens.y;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 80f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        
    }
}
