using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void ClickToStart()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene(1);
    }
    
    public void ClickToCredit()
    {
        Debug.Log("Credit");
        SceneManager.LoadScene(2);
    }

    public void ClickToQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    
    public void ClickToMenu()
    {
        Debug.Log("Go to menu");
        SceneManager.LoadScene(0);
    }
}
