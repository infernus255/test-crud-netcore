using System;

namespace test_crud.core.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {

        }

        public BusinessException(string msj) : base(msj)
        {

        }
    }
}
