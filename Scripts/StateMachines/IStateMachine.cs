public interface IStateMachine<TAction>
    where TAction : Enum
{
    public abstract IResponse? ProcessAction(TAction action, IRequest request);
    public abstract IState GetNextState(IState current, TAction action);
}