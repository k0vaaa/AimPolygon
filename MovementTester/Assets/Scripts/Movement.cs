 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
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
        float mouseX = Time.fixedDeltaTime * Input.GetAxisRaw("Mouse X") * sensX;
        float mouseY = Time.fixedDeltaTime * Input.GetAxisRaw("Mouse Y") * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 60f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        
    }
}
