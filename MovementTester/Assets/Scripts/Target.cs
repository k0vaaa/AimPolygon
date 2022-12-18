using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    public float health = 50f;
    
    public GameObject Eliminatelist;

    public Animator anims;
    

    void Start(){
        Eliminatelist.SetActive(false);
    }

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
        // Eliminatelist.SetActive(true);
        
    }
    
    public void CancelAnimation(){ 
        // Eliminatelist.SetActive(false);
    }
}
