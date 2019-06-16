using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.ExceptionsProjekat
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException()
        {
        }

        public DataNotFoundException(string data) : base($"{data} ne postoji.")
        {
        }
    }
}
