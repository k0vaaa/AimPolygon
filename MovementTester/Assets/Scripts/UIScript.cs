using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class UIScript : MonoBehaviour
{
    private Shooting shootFunc;
    public TMPro.TextMeshProUGUI textMy;

    void Start()
    {   
        GameObject searchGun = GameObject.Find("Gun");
        Shooting gunStats = searchGun.GetComponent<Shooting>();
        textMy.text = gunStats.ammo.ToString();
    }

    void Update()
    {   
        GameObject searchGun = GameObject.Find("Gun");
        Shooting gunStats = searchGun.GetComponent<Shooting>();

        if((Input.GetButtonDown("Fire1"))){
            
            if(gunStats.ammo!=0){
            gunStats.ammo--;
            textMy.text = gunStats.ammo.ToString();
            }

            else{
                gunStats.fireready = false;
                gameObject.GetComponent<Shooting>().Reload();
            }
        }
    }
    
}
