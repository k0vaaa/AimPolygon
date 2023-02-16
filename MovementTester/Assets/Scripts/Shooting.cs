using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting: MonoBehaviour
{
    // public ParticleSystem Sparks;
    // public GameObject spark;

    [Header("Bullet impacts to wooden objects")]
    public ParticleSystem sparksWood;
    public GameObject spark_wood;

    [Header("Bullet impacts to metal objects")]
    public ParticleSystem SparksMetal;
    public GameObject spark_metal;
    public float lifeTimeMetal = 5.0f;
    private GameObject clonem;
    private GameObject[] bulletimpact2;
    
    [Header("Bullet impacts to enemy flesh objects")]
    public ParticleSystem SparksFlesh;
    public GameObject spark_flesh;
    private GameObject clonef;
    // private GameObject[] bulletimpact1;
    // public float lifeTimeFlesh = 5.0f;


    // public ParticleSystem Sparks;
    // public GameObject spark;

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
    public RaycastHit hit;
    // public bool picked;
    
    void Start()
    {
        // picked = false;
        startammo = ammo;
        ammotext.text = startammo.ToString();
        fireready = true;
    }
    
    void Update()
    {   
        // if(picked==false){
        //     return;
        // }
        if (Input.GetButtonDown("Fire1") && fireready){
            
            
            if(ammo==0){
            _noBulletsAnim.SetBool("NoBullets",true);
            reloadalert.text = "Press <R> to reload";
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
        if ((Input.GetKeyDown(KeyCode.R) && fireready == true)  || (Input.GetKeyDown(KeyCode.R) && ammo == 0)){
            Reload();


        }
        // if (Input.KeyUp(KeyCode.R)){
        //     _animator.SetBool("Reloading",false);
        // }

        
        
    }
    
    void Shoot()
    {   
        _animator.SetBool("CurrentShoot",true);
        particle.Play();

        

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)){
            // Debug.DrawRay(cam.transform.position, cam.transform.forward*100f, Color.red,1,false);
            
            DotSpawn.hitted= hit.transform.name;
            Target target = hit.transform.GetComponent<Target>();
            Dot dot = hit.transform.GetComponent<Dot>();
            Wood box = hit.transform.GetComponent<Wood>();
            
            if (target != null)
            {
                target.TakeDamage(damage);
                // clonef = Instantiate(spark_flesh, hit.point, Quaternion.LookRotation(hit.normal)); 
                // clonef.tag= "trashf";
                spark_flesh.transform.position = hit.point;
                spark_flesh.transform.rotation = Quaternion.LookRotation(hit.normal);
                SparksFlesh.Play();



                // bulletimpact2 = GameObject.FindGameObjectsWithTag("trashf");
                // foreach(GameObject i in bulletimpact2){
                //     Destroy(i, lifeTimeFlesh);
                // }
            }
            else if(dot !=null)
            {
                dot.TakeDamage();
                // spark_metal.transform.position = hit.point;
                // spark_metal.transform.rotation = Quaternion.LookRotation(hit.normal);
                SparksMetal.Play();
                // Destroy(ddddddddddddddddddddddddspark_metal);
            }

            else if(box !=null){
                spark_wood.transform.position = hit.point;
                spark_wood.transform.rotation = Quaternion.LookRotation(hit.normal);
                sparksWood.Play();
            }

            else {
                clonem = Instantiate(spark_metal, hit.point, Quaternion.LookRotation(hit.normal)); 
                clonem.tag= "trashm";
                SparksMetal.Play();
                bulletimpact2 = GameObject.FindGameObjectsWithTag("trashm");
                foreach(GameObject i in bulletimpact2){
                    Destroy(i, lifeTimeMetal);
                }
                
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
