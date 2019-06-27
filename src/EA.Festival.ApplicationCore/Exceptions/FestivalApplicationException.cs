using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EA.Festival.ApplicationCore.Exceptions
{
    public class FestivalApplicationException : ApplicationException
    {
        public FestivalApplicationException(HttpResponseMessage response, string responseContent) : 
            base($"Music Festival API response: code={response.StatusCode}, text={response.ReasonPhrase}, content={responseContent}")
        {
        }

        protected FestivalApplicationException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        public FestivalApplicationException(string message) : base(message)
        {
        }

        public FestivalApplicationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
