using System;

namespace Method_Chain
{
    public class Creature
    {
        public string Name;
        public int Attack, Defense;

        public Creature(string name, int attack, int defense)
        {
            if (attack <= 0) throw new ArgumentOutOfRangeException(nameof(attack));
            if (defense <= 0) throw new ArgumentOutOfRangeException(nameof(defense));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Attack = attack;
            Defense = defense;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
        }
    }

    public class CreatureModifier
    {
        protected Creature Creature;
        protected CreatureModifier Next;

        public CreatureModifier(Creature creature)
        {
            Creature = creature ?? throw new ArgumentNullException(nameof(creature));
        }

        public void Add(CreatureModifier creatureModifier)
        {
            if (Next != null) Next.Add(creatureModifier);
            else Next = creatureModifier;
        }

        public virtual void Handle() => Next?.Handle();
    }

    public class IncreaseDefenseModifier : CreatureModifier
    {
        public IncreaseDefenseModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            Console.WriteLine($"Increasing {Creature.Name}'s Defense");
            Creature.Defense += 3;
            base.Handle();
        }
    }

    public class DoubleAttackModifier : CreatureModifier
    {
        public DoubleAttackModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            Console.WriteLine($"Doubling {Creature.Name}'s Attack");
            Creature.Attack *= 2;
            base.Handle();
        }
    }

    public class NoBonusesModifier : CreatureModifier
    {
        public NoBonusesModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var goblin = new Creature("Goblin", 2, 2);

            Console.WriteLine(goblin);

            var rootModifier = new CreatureModifier(goblin);

            Console.WriteLine("Disable adding bonuses!");
            rootModifier.Add(new NoBonusesModifier(goblin));

            Console.WriteLine("Let's double the goblin's attack");
            rootModifier.Add(new DoubleAttackModifier(goblin));

            Console.WriteLine("Let's increase the goblin's defense");
            rootModifier.Add(new IncreaseDefenseModifier(goblin));

            rootModifier.Handle();
            Console.WriteLine(goblin);
        }
    }
}