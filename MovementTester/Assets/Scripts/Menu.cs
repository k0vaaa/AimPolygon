using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{   
    public Sens sens;
    public GameObject modeselect;
    public GameObject settingsview;
    public Slider sensx;
    public Slider sensy;
    public InputField sensxsign;
    public InputField sensysign;


    public void Start(){
        Debug.Log(sens.x);
        Debug.Log(sens.y);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        modeselect.SetActive(false);
        settingsview.SetActive(false);
        
        sensx.value = sens.x;
        sensy.value = sens.y;
        sensxsign.text = Mathf.Round(sensx.value).ToString(); 
        sensysign.text = Mathf.Round(sensy.value).ToString();
    }
    
    public void SensSetX(){
        
        sensxsign.text = Mathf.Round(sensx.value).ToString(); 
        
        sens.x = Mathf.Round(sensx.value);

    }
    public void SensSetY(){
        
        sensysign.text = Mathf.Round(sensy.value).ToString();
        
        sens.y = Mathf.Round(sensy.value);

    }




    public void ModeSelect()
    {
        modeselect.SetActive(true);
    }
    public void Settings()
    {
        settingsview.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void CloseSelection()
    {
        modeselect.SetActive(false);
    }
    public void CloseSettings()
    {
        settingsview.SetActive(false);
    }

    public void Mode1Select()
    {
        SceneManager.LoadScene(1);
    }

    public void Mode2Select()
    {
        SceneManager.LoadScene(2);
    }



}
