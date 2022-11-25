using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public int ammo;
    public Camera cam;
    public ParticleSystem particle;
    public Animator _animator;
    public bool fireready;
    private int startammo;

    void Start()
    {
        fireready = true;
        startammo = ammo;
    }
    
    void Update()
    {   
        if (Input.GetButtonDown("Fire1") && fireready){
            _animator.SetBool("CurrentShoot",true);
            Shoot();

        }
        else {
            _animator.SetBool("CurrentShoot",false);
        }

        if (Input.GetKey(KeyCode.R)){
            Reload();
        }
    }
    void Shoot()
    {   
        particle.Play();
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)){
            // Debug.DrawRay(cam.transform.position, cam.transform.forward*100f, Color.red,1,false);
            Debug.Log(hit.transform.name);
            
            Target target = hit.transform.GetComponent<Target>();
            
            if (target != null)
            {
                target.TakeDamage(damage);
            

            }
        }
    }
    public void Reload()
    {
        ammo = startammo;
        fireready = true;
        gameObject.GetComponent<UIScript>().textMy.text = ammo.ToString();
    }
    
}
