using System.Collections.Generic;

namespace Manager.Domain.Entities
{
    public abstract class Base
    {
        public long Id { get; set; }
        internal IList<string> _erros;
        public IReadOnlyCollection<string> Errors => (IReadOnlyCollection<string>)_erros;
        public abstract bool Validate();
    }
}