using UnityEngine;

public class Merchant : MonoBehaviour
{
    public static Merchant Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<PlayerInteract>().canInteract = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<PlayerInteract>().canInteract = false;
    }
}
