using UnityEngine;
using UnityEngine.UI;

public class Fullscreen : MonoBehaviour
{
   
   public void SetfullScreen(bool fullscreen)
    {
        Screen.fullScreen = !Screen.fullScreen;
        print("Screen size changed successfully");    
    }   
}
