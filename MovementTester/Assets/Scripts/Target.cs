using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    public float health = 50f;
    

    // public Animator anims;
    

    public void TakeDamage(float amount)
    {
        
        health -=amount;
        if (health <=0)
        {
            Destroy();
        }
    }
    void Destroy()
    {   
        Destroy(gameObject);
        
    }
    
}
