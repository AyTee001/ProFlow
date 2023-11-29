namespace ProFlow.Core.DAL.Exceptions
{
    public sealed class PreconditionFailedException : Exception
    {
        public PreconditionFailedException(string name, string id)
            : base($"Precondition failed for entity {name} (id: {id}).") { }

        public PreconditionFailedException(string name) : base($"Precondition failed for entity {name}") { }

    }
}
