using System;
using UnityEngine;
using DG.Tweening;

public class Shell : MonoBehaviour
{
    public float shellOffset;
    public float shellSpeed;

    public float startY;
    
    private void Awake()
    {
        startY = transform.position.y;
        transform.DOMoveY(startY+shellOffset, shellSpeed).SetLoops(-1, LoopType.Yoyo);
 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats.Instance.SetCurrency(PlayerStats.Instance.GetCurrency() + 1);
            Destroy(gameObject);
        }
    }
}
