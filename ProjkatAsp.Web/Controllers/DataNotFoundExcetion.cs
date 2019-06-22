using System;
using System.Runtime.Serialization;

namespace ProjkatAsp.Web.Controllers
{
    [Serializable]
    internal class DataNotFoundExcetion : Exception
    {
        public DataNotFoundExcetion()
        {
        }

        public DataNotFoundExcetion(string message) : base(message)
        {
        }

        public DataNotFoundExcetion(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DataNotFoundExcetion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}