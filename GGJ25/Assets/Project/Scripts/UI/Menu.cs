using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

 public void StartButton() 
    {
        SceneManager.LoadScene(1);
    }

public void QuitButton()
    {

        Application.Quit(); 

    }

}
