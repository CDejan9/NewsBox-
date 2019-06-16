using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.ExceptionsProjekat
{
    public class DataAlreadyExistsException : Exception
    {
        public DataAlreadyExistsException()
        {
        }

        public DataAlreadyExistsException(string data) : base($"{data} vec postoji.")
        {
        }
    }
}
