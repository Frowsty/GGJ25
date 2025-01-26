using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject gameOverScreen;
    public GameObject playingScreen;


    private void Awake()
    {
        if(instance == null)
            instance = this;
        else if(instance != this)
            Destroy(this);
        
            
        
    }

    public void ShowGameOverScreen()
    {
        //playingScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }


    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
