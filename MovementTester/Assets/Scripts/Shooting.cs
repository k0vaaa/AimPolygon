using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public ParticleSystem Sparks;
    public GameObject spark;
    public float damage = 10f;
    public float range = 100f;
    public int ammo;
    public Camera cam;
    public ParticleSystem particle;
    public Animator _animator;
    public bool fireready;
    private int startammo;
    public TMPro.TextMeshProUGUI ammotext;
    public TMPro.TextMeshProUGUI reloadalert;
    public Animator _noBulletsAnim;
    private RaycastHit hit;
    void Start()
    {
        startammo = ammo;
        ammotext.text = startammo.ToString();
        fireready = true;
    }
    
    void Update()
    {   
        if (Input.GetButtonDown("Fire1") && fireready){
            
            
            if(ammo==0){
            _noBulletsAnim.SetBool("NoBullets",true);
            reloadalert.text = "Нажмите 'R' для перезарядки";
            fireready = false; 
            
            }

            else{
                Shoot();
                ammo--;
                ammotext.text = ammo.ToString();
            }  

        }
        else {
            _animator.SetBool("CurrentShoot",false);
            
        }
        if (Input.GetKey(KeyCode.R)){
            _animator.SetBool("Reloading",true);
            Reload();
        }
        
    }
    
    void Shoot()
    {   
        _animator.SetBool("CurrentShoot",true);
        particle.Play();

        

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)){
            // Debug.DrawRay(cam.transform.position, cam.transform.forward*100f, Color.red,1,false);
            Debug.Log(hit.transform.name);
            
            Target target = hit.transform.GetComponent<Target>();
            
            if (target != null)
            {
                target.TakeDamage(damage);
                
                spark.transform.position = hit.point;
                spark.transform.rotation = Quaternion.LookRotation(hit.normal);

                Sparks.Play();
            }
        }


    }

    public void Reload()
    {   
        fireready = false;
        _animator.SetBool("Reloading",true);
        reloadalert.text = "";
    }

    public void CancelAnimation(){
        ammo = startammo;
        _noBulletsAnim.SetBool("NoBullets",false);
        ammotext.text = ammo.ToString();
        _animator.SetBool("Reloading",false);
        fireready = true;
    }    

}
