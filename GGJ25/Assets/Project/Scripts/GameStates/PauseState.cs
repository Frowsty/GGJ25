using UnityEngine;

public class PauseState : State
{
    public override void EnterState()
    {
        Debug.Log("Entering Pause state");
    }

    public override void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameManager.Instance.SwitchState<PlayingState>();
    }
    public override void FixedUpdateState() {}

    public override void ExitState()
    {
        Debug.Log("Exiting Pause state");
    }
}
