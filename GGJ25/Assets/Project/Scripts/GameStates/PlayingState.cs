using UnityEngine;

public class PlayingState : State
{
    public override void EnterState()
    {
        Debug.Log("Entering play state");
    }

    public override void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameManager.Instance.SwitchState<PauseState>();
    }
    public override void FixedUpdateState() {}

    public override void ExitState()
    {
        Debug.Log("Exiting play state");
    }
}