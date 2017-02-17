using System;

namespace BoilerWebApiCore.Shared
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public BusinessException(string message)
            : base(message)
        {
        }
    }
}