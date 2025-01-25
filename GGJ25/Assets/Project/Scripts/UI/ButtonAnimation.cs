using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float targetScale = 1.2f;
    public float delay = 0.5f;
    public Ease easeIn;
    public Ease easeOut= Ease.OutBounce;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    private void OnDisable()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(targetScale, delay).SetEase(easeIn);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1, delay).SetEase(easeOut);
    }
}
