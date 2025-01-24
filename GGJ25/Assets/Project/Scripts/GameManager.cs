using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public virtual void EnterState() {}
    public virtual void UpdateState() {}
    public virtual void FixedUpdateState() {}
    public virtual void ExitState() {}
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public State[] states;
    public State currentState;

    private Player Player { get; set; }

    public void SwitchState<T>() where T : State
    {
        foreach (State s in states)
        {
            if (s.GetType() == typeof(T))
            {
                currentState?.ExitState();
                currentState = s;
                currentState.EnterState();
                return;
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        states = GameObject.FindObjectsByType<State>(FindObjectsSortMode.None);
        
        SwitchState<PlayingState>();
    }
    
    private void Update()
    {
        currentState?.UpdateState();
    }

    private void FixedUpdate()
    {
        currentState?.FixedUpdateState();
    }
}
