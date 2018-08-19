namespace C2C.Core.Contracts
{
    public interface ICameraOperations : IOperations
    {
        string ZoomIn(int factor);
        string ZoomOut(int factor);
    }
}
