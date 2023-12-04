using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject instructions;
    public void btnNewGameClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void btnQuitClick()
    {
        Application.Quit();
    }    
    public void btnInstructionsClick()
    {
        instructions.SetActive(true);
    }
    public void btnCloseIntructionsClick()
    {
        instructions.SetActive(false);
    }
}
