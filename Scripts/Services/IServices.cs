public interface IService
{
    public abstract IResponse? ProcessRequest(IRequest request);
}