using System;
using System.Runtime.Serialization;
namespace NetC.JuniorDeveloperExam.Web.Models
{
    [Serializable]
    internal class BlogNotFoundException : Exception
    {
        private readonly int id;

        public BlogNotFoundException()
        {
        }

        public BlogNotFoundException(int id)
        {
            this.id = id;
        }

        public BlogNotFoundException(string message) : base(message)
        {
        }

        public BlogNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BlogNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}