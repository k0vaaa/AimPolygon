using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dot;
    public GameObject canvas;
    Vector3 myVector;
    
    
    void Start()
    {   
        (float y, float z) = RandomGenerator();
        Instantiate(dot, new Vector3(18.945362091064454f,y,z), Quaternion.identity); 
        
    }
    
    void Update()
    {

        if (GameObject.Find("Sphere(Clone)") == null){
            (float y, float z) = RandomGenerator();
            Instantiate(dot, new Vector3(18.945362091064454f,y,z), Quaternion.identity); 
        }
        
    }

    

    static (float y, float z) RandomGenerator(){
        float y = Random.Range(11f, 28.5f);
        float z = Random.Range(-56f, -91f);
        return(y,z);
    }
}