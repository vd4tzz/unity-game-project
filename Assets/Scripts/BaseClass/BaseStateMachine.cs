

public class BaseStateMachine
{
    protected BaseState currentState;

    public virtual void ChangeState(BaseState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public virtual void Update()
    {
        currentState.Execute();
    }
}
