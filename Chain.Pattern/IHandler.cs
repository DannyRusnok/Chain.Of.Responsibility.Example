using System.ComponentModel.DataAnnotations;

namespace Chain.Of.Responsibility.Example.Chain.Pattern
{
    public interface IHandler<T>
    {
        void Handle(T request);
        IHandler<T> SetNext(IHandler<T> next);
    }
}