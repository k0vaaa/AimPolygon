using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{

    public Animator anims;
    

    public void TakeDamage()
    {
        
        Destroy();

    }
    void Destroy()
    {   
        Destroy(gameObject);  
    }       
}
