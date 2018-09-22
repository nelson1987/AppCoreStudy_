using System;
using System.Runtime.Serialization;

namespace AppCoreStudy.Entities
{
    [Serializable]
    internal class AppCoreStudyDomainValidationException : Exception
    {
        public AppCoreStudyDomainValidationException()
        {
        }

        public AppCoreStudyDomainValidationException(string message) : base(message)
        {
        }

        public AppCoreStudyDomainValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AppCoreStudyDomainValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}