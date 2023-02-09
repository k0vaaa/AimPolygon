using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSettings : MonoBehaviour
{   
    private KeyCode menu = KeyCode.Escape;
    private KeyCode reloadScene = KeyCode.BackQuote;
    public GameObject enemy;
    Vector3 myVector;

    void Update()
    {   
        if(Input.GetKey(reloadScene)){
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
        if(Input.GetKey(menu)){ 
            SceneManager.LoadScene(0);
        }
        
        if (GameObject.Find("EnemyBody(Clone)") == null)
        {
            (float x, float z) = RandomGenerator();
            Instantiate(enemy, new Vector3(x,1f,z), Quaternion.identity); 
        }
    }

    static (float x, float z) RandomGenerator(){
        float x = Random.Range(-25f, 17f);
        float z = Random.Range(35f,71f);
        return(x,z);
    }
}
