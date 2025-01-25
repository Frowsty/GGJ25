using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public SpriteRenderer bg;
    private void Start()
    {
        if(bg != null)
            bg=GameObject.FindGameObjectWithTag("BackGround").GetComponent<SpriteRenderer>();    
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(EndRoutine());
        }
    }


    public IEnumerator EndRoutine()
    {
        float t=0f;
        
        bg.DOColor(new Color(0, 0, 0, 1f), 0.4f);
        yield return new WaitForSeconds(0.4f);
        LevelGenerator.Instance.ResetAndIncrease();
        bg.DOColor(new Color(0, 0, 0, 0f), 0.4f);
        
    }
    
    
}
