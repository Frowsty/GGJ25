using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject SettingsUI;
    public GameObject StartMenuUI;


    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }


    public void EnableSettingsUI()
    {
        SettingsUI.SetActive(true);
        
        StartMenuUI.SetActive(false);
    }

    public void DisableSettingsUI()
    {
        SettingsUI.SetActive(false);

        StartMenuUI.SetActive(true );
    }



    public void QuitButton()
    {
        Application.Quit();
    }

}
