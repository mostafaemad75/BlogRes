using System;
using System.Collections.Generic;
using System.Text;

namespace MultiCulturalBlog.Model.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException() { }

        public EntityAlreadyExistsException(string message) : base(message) { }
    }
}
