using System;
using System.Collections.Generic;

namespace Manager.Core.Exceptions
{
    public class DomainException : Exception
    {
        internal IList<string> _errors;
        public IReadOnlyCollection<string> Errors => (IReadOnlyCollection<string>)_errors;
        public DomainException()
        {}

        public DomainException(string mensage, IList<string> errors) : base(mensage)
        {
            _errors = errors;
        }

        public DomainException(string mensage) : base(mensage)
        { }

        public DomainException(string mensage, Exception innerException) : base(mensage)
        {}
    }
}
