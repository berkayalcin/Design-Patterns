using Autofac;
using NUnit.Framework;

namespace Hated_Singleton
{
    [TestFixture]
    public class SingletonTests
    {
        [Test]
        public void IsSingletonTest()
        {
            var db = SingletonDatabase.Db;
            var db2 = SingletonDatabase.Db;

            Assert.That(db, Is.SameAs(db2));
            Assert.That(SingletonDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public void SingletonTotalPopulationTest()
        {
            var rf = new SingletonRecordFinder();
            var names = new[] {"Tokyo", "New Jersy"};
            int tp = rf.GetTotalPopulation(names);

            Assert.That(tp, Is.EqualTo(130010));
        }

        [Test]
        public void ConfigurablePopulationTest()
        {
            var rf = new ConfigurableRecordFinder(new DummyDatabase());
            var names = new[] {"alpha", "gamma"};
            int tp = rf.GetTotalPopulation(names);
            Assert.That(tp, Is.EqualTo(1 + 3));
        }

        [Test]
        public void DIPopulationTest()
        {
            var cb = new ContainerBuilder();

            cb
                .RegisterType<DummyDatabase>()
                .As<IDatabase>()
                .SingleInstance();

            cb.RegisterType<ConfigurableRecordFinder>();
            using var container = cb.Build();
            var names = new[] {"alpha", "gamma"};

            var tp = container.Resolve<ConfigurableRecordFinder>().GetTotalPopulation(names);
            Assert.That(tp, Is.EqualTo(1 + 3));
        }
    }
}