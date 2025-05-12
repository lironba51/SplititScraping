using System;

namespace SplitItScrap.Domain.ErrorHandlers.Actors
{
    public class ActorNotFoundException : Exception
    {
        public ActorNotFoundException(string message) : base(message) { }
    }
}
