public interface IEntity<TAction>
    where TAction : Enum
{
    public IStateMachine<TAction> FSM { get; set; }
    public Location Location { get; set; }
    public IState CurrentState { get; set; }

    public abstract void Update();
    public abstract void HandleInput(TAction input);
    public abstract void SendRequest(TAction action);
    public abstract void ProcessResponse(IResponse response);
}