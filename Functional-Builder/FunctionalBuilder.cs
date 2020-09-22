using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional_Builder
{
    public abstract class FunctionalBuilder<TSubject, TSelf>
        where TSelf : FunctionalBuilder<TSubject, TSelf>
        where TSubject : new()
    {
        private readonly List<Func<TSubject, TSubject>> _actions =
            new List<Func<TSubject, TSubject>>();

        public TSubject Build() => _actions.Aggregate(new TSubject(),
            (p, f) => f(p));

        private TSelf AddAction(Action<TSubject> action)
        {
            _actions.Add(p =>
            {
                action(p);
                return p;
            });
            return (TSelf) this;
        }

        public TSelf Do(Action<TSubject> action)
        {
            AddAction(action);
            return (TSelf) this;
        }
    }
}