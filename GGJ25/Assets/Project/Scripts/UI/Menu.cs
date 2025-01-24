using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject SettingsUI;


    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }


    public void EnableSettingsUI()
    {
        SettingsUI.SetActive(true);
    }

    public void DisableSettingsUI()
    {
        SettingsUI.SetActive(false);
    }



    public void QuitButton()
    {
        Application.Quit();
    }

}
