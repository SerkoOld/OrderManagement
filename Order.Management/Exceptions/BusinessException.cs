using System;

namespace Order.Management.Exceptions
{
    public class BusinessException: Exception
    {
        protected BusinessException(string message): base(message)
        {

        }
    }
}