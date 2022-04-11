public interface IEntity<TAction>
    where TAction : Enum
{
    public IStateMachine<TAction> FSM { get; set; }
    public Location Location { get; set; }
}