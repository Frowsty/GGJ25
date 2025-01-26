using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PanelAnimation : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        transform.localScale = Vector3.zero;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(2f, 0.5f).SetEase(Ease.OutBounce);
    }
}
