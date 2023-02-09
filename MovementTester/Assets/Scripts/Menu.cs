using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject modeselect;

    public void Start(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        modeselect.SetActive(false);
    }

    public void ModeSelect()
    {
        modeselect.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void CloseSelection()
    {
        modeselect.SetActive(false);
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
