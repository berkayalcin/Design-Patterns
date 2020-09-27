using System;

namespace Broker_Chain
{
    public class Game
    {
        public event EventHandler<Query> Queries;

        public void PerformQuery(object sender, Query query)
        {
            Queries?.Invoke(sender, query);
        }
    }

    public class Query
    {
        public string CreatureName;
        public Argument WhatToQuery;
        public int Value;

        public Query(string creatureName, Argument whatToQuery, int value)
        {
            CreatureName = creatureName ?? throw new ArgumentNullException(nameof(creatureName));
            WhatToQuery = whatToQuery;
            Value = value;
        }

        public enum Argument
        {
            Attack,
            Defense
        }
    }

    public class Creature
    {
        private Game _game;
        public string Name;
        private int _attack, _defense;

        public Creature(Game game, string name, int attack, int defense)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            _attack = attack;
            _defense = defense;
        }

        public int Attack
        {
            get
            {
                var query = new Query(Name, Query.Argument.Attack, _attack);
                _game.PerformQuery(this, query);
                return query.Value;
            }
        }

        public int Defense
        {
            get
            {
                var query = new Query(Name, Query.Argument.Defense, _attack);
                _game.PerformQuery(this, query);
                return query.Value;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
        }
    }

    public abstract class CreatureModifier : IDisposable
    {
        protected Game Game;
        protected Creature Creature;

        protected CreatureModifier(Game game, Creature creature)
        {
            Game = game ?? throw new ArgumentNullException(nameof(game));
            Creature = creature ?? throw new ArgumentNullException(nameof(creature));
            game.Queries += Handle;
        }

        protected abstract void Handle(object sender, Query query);

        public void Dispose()
        {
            Game.Queries -= Handle;
        }
    }

    public class IncreaseDefenseModifier : CreatureModifier
    {
        public IncreaseDefenseModifier(Game game, Creature creature) : base(game, creature)
        {
        }

        protected override void Handle(object sender, Query query)
        {
            if (query.CreatureName == Creature.Name && query.WhatToQuery == Query.Argument.Defense)
                query.Value += 3;
        }
    }

    public class DoubleAttackModifier : CreatureModifier
    {
        public DoubleAttackModifier(Game game, Creature creature) : base(game, creature)
        {
        }

        protected override void Handle(object sender, Query query)
        {
            if (query.CreatureName == Creature.Name && query.WhatToQuery == Query.Argument.Attack)
                query.Value *= 2;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            var goblin = new Creature(game, "Strong Goblin", 3, 3);
            Console.WriteLine(goblin);

            using (new DoubleAttackModifier(game, goblin))
            {
                Console.WriteLine(goblin);
                using (new IncreaseDefenseModifier(game, goblin))
                    Console.WriteLine(goblin);
            }

            Console.WriteLine(goblin);
        }
    }
}