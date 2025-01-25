using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private IPlayerComponent[] components;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        components = GetComponentsInChildren<IPlayerComponent>();
        
        LevelGenerator.Instance.StartGeneration();
    }

    // Update is called once per frame
    public void UpdatePlayer()
    {
        foreach (var component in components)
            component.UpdateComponent();
    }
}

interface IPlayerComponent
{
    public void UpdateComponent();
}

