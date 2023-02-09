using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DotSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dot;
    Vector3 myVector;
    // private int flag = 0;
    public TMPro.TextMeshPro sign;
    public TMPro.TextMeshPro tip;
    public static string hitted;
    private KeyCode reloadScene = KeyCode.BackQuote;
    private KeyCode menu = KeyCode.Escape;
    
    void Update()
    {
        if(Input.GetKey(reloadScene)){
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
        if(Input.GetKey(menu)){ 
            SceneManager.LoadScene(0);
        }
        if (GameObject.Find("Sphere(Clone)") == null)
        {
            (float y, float z) = RandomGenerator();
            Instantiate(dot, new Vector3(-10.25f,y,z), Quaternion.identity); 
        }
        if (hitted == "SmallTip"){
            StartGame();
        }
        
    }
    


    static (float y, float z) RandomGenerator(){
        float y = Random.Range(5.25f, 14.75f);
        float z = Random.Range(-11.75f,7.25f);
        return(y,z);
    }

    void StartGame()
    {
        Destroy(GameObject.Find("Sphere(Clone)"),1);
        hitted = "";
        sign.gameObject.SetActive(false);
        tip.gameObject.SetActive(false);
        // (float y, float z) = RandomGenerator();
        // Instantiate(dot, new Vector3(-10.25f,y,z), Quaternion.identity); 
    }
    
}