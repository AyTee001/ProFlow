namespace ProFlow.Core.Common.Exceptions
{
    public sealed class NotFoundException : Exception
    {
        public NotFoundException(string name, string id)
            : base($"Entity {name} not found (id: {id}).") { }

        public NotFoundException() : base($"Entity not found.") { }
    }
}
