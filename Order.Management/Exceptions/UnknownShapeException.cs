namespace Order.Management.Exceptions
{
    public class UnknownShapeException: BusinessException
    {
        public UnknownShapeException(string shape): base("Invalid Shape: {shape}")
        {

        }
    }
}