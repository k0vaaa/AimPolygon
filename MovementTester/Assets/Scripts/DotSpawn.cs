using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DotSpawn : MonoBehaviour
{
    public Sens sens;
    public GameObject dot;
    Vector3 myVector;

    public TMPro.TextMeshPro sign;
    public TMPro.TextMeshPro tip;
    public TMPro.TextMeshProUGUI hits;
    public TMPro.TextMeshProUGUI accuracy;
    public TMPro.TextMeshProUGUI timer;
    public TMPro.TextMeshProUGUI hitsSign;
    public TMPro.TextMeshProUGUI accuracySign;
    public TMPro.TextMeshProUGUI timerSign;


    public TMPro.TextMeshPro gameOver;
    public TMPro.TextMeshPro checkStats;
    public TMPro.TextMeshPro stat1Sign;
    public TMPro.TextMeshPro stat1;
    public TMPro.TextMeshPro stat2Sign;
    public TMPro.TextMeshPro stat2;
    public TMPro.TextMeshPro stat3Sign;
    public TMPro.TextMeshPro stat3;





    public static string hitted;
    private KeyCode reloadScene = KeyCode.BackQuote;
    private KeyCode menu = KeyCode.Escape;
    public bool gamestarted;
    public float timeStart = 60;
    
    int totalshots = 0;
    int totalhits = 0;
    int gamesPlayed = 0;
    void Start()
    {   
        timer.text = timeStart.ToString() + "s";
        EndGame();
        gamestarted = false;
        
    }

    void Update()
    {
        if(Input.GetKey(reloadScene)){
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
        if(Input.GetKey(menu)){ 
            SceneManager.LoadScene(0);
        }
        Mechanic();
        
        if (hitted == "SmallTip"){
            gamesPlayed++;
            Debug.Log("Это "+gamesPlayed+"я игра");
            StartCoroutine(StartGame());
            
            StartGame();
        }
        if (Input.GetButtonDown("Fire1") && gamestarted)
        {
            (int shotss, float accc, int hitss) = StatCalc(totalshots, totalhits);
            hits.text = hitss.ToString();
            accuracy.text = accc.ToString()+ "%";
            // hits.text = counthits.ToString();  
            totalshots = shotss;
            totalhits = hitss;
        }
        
    } 

    
    
    void Mechanic(){
        
        if(gamestarted==true){
            if (GameObject.Find("Sphere(Clone)") == null)
            {
                (float y, float z) = RandomGenerator();
                Instantiate(dot, new Vector3(-10.25f,y,z), Quaternion.identity);
            }
            timeStart -=Time.deltaTime;
            timer.text = Mathf.Round(timeStart).ToString()+"s";
            if(timeStart < 0){
                gamestarted = false;
                
            }
        if(gamestarted==false) {
            EndGame();
            Results();
        }
        }
    }

    static (float y, float z) RandomGenerator(){
        float y = Random.Range(5.25f, 14.75f);
        float z = Random.Range(-11.75f,7.25f);
        return(y,z);
    }
    
    IEnumerator StartGame()
    {   
        timeStart = 60;
        totalshots = 0;
        totalhits = 0;
        hitted = "";
    
        gameOver.gameObject.SetActive(false);
        checkStats.gameObject.SetActive(false);
        stat1Sign.gameObject.SetActive(false);
        stat2Sign.gameObject.SetActive(false);
        stat3Sign.gameObject.SetActive(false);
        stat1.gameObject.SetActive(false);
        stat2.gameObject.SetActive(false);
        stat3.gameObject.SetActive(false);
        sign.gameObject.SetActive(false);
        tip.gameObject.SetActive(false);
        hits.gameObject.SetActive(true);
        accuracy.gameObject.SetActive(true);
        hitsSign.gameObject.SetActive(true);
        accuracySign.gameObject.SetActive(true);
        timer.gameObject.SetActive(true);
        timerSign.gameObject.SetActive(true);
        timer.text = timeStart.ToString()+"s";
        yield return new WaitForSeconds(3);
        gamestarted = true;
        // Task.Delay(2000).GetAwaiter().GetResult(); 
        // зависание ВСЕГО приложения (мб когда то пригодится)
    }

    void EndGame(){
        
        /*КОСТЫЛЬ ЖУТКИЙ*/
        if(gamesPlayed>0){
            tip.text = "RESTART";
        }
        /*---------------*/
        tip.gameObject.SetActive(true);
        hits.gameObject.SetActive(false);
        timer.gameObject.SetActive(false);
        accuracy.gameObject.SetActive(false);
        hitsSign.gameObject.SetActive(false);
        accuracySign.gameObject.SetActive(false);
        timerSign.gameObject.SetActive(false);
        Destroy(GameObject.Find("Sphere(Clone)"));
        gameOver.gameObject.SetActive(false);
        checkStats.gameObject.SetActive(false);
        stat1Sign.gameObject.SetActive(false);
        stat2Sign.gameObject.SetActive(false);
        stat3Sign.gameObject.SetActive(false);
        stat1.gameObject.SetActive(false);
        stat2.gameObject.SetActive(false);
        stat3.gameObject.SetActive(false);
    }

    void Results(){
        (int shotss, float accc, int hitss) = StatCalc(totalshots, totalhits);
        totalshots = totalshots-1;
        totalhits = totalhits-1;
        (int finalshots, float finalacc, int finalhits) = StatCalc(totalshots, totalhits);
        gameOver.gameObject.SetActive(true);
        checkStats.gameObject.SetActive(true);
        stat1Sign.gameObject.SetActive(true);
        stat2Sign.gameObject.SetActive(true);
        stat3Sign.gameObject.SetActive(true);
        stat1.text = finalhits.ToString();
        stat2.text = finalshots.ToString();
        stat3.text = finalacc.ToString()+ "%";
        stat1.gameObject.SetActive(true);
        stat2.gameObject.SetActive(true);
        stat3.gameObject.SetActive(true);
    }

    static (int shotss, float accc, int hitss) StatCalc(int totalshots, int totalhits)
    {
        float acc = 100;
        if (hitted != "")
        {
            totalshots++;
            if (hitted == "Sphere(Clone)")
            {
                totalhits++;
            }
            if (totalshots != 0)
            {
                acc = (int)(((float)totalhits / (float)totalshots)*100);
            }
        }
        return (totalshots, acc, totalhits);
    }
    
}