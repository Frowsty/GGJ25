using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject SettingsUI;
    public GameObject StartMenuUI;
    public GameObject CreditsUI;

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }


    public void EnableSettingsUI()
    {
        SettingsUI.SetActive(true);
        
        StartMenuUI.SetActive(false);
        
        CreditsUI.SetActive(false);
    }

    public void DisableSettingsUI()
    {
        SettingsUI.SetActive(false);

        StartMenuUI.SetActive(true);
        
        CreditsUI.SetActive(false);
    }

    public void EnableCreditsUI()
    {
        SettingsUI.SetActive(false);

        StartMenuUI.SetActive(false);
        
        CreditsUI.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
