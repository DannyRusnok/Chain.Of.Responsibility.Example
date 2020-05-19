namespace Chain.Of.Responsibility.Example.Chain.Pattern
{
    public abstract class Handler<T>
    {
        private IHandler<T> Next { get; set; }

        public virtual void Handle(T request)
        {
            Next?.Handle(request);
        }

        public IHandler<T> SetNext(IHandler<T> next)
        {
            Next = next;
            return Next;
        }
    }
}