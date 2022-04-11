public interface IStateMachine<TAction>
    where TAction : Enum
{
    public IState CurrentState { get; }
    public abstract void SetState(IState state);
    public abstract IResponse? ProcessAction(TAction action, IRequest? request);
    public abstract IState ChangeState(IState current, TAction action);
}