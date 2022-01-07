using System;
using System.Linq;
using NUnit.Framework;
using Nova.Framework.Dependency;

namespace Nova.Framework.Tests.Dependency
{
    public class DependencyContainerTest
    {
        [Test]
        public void Should_Return_Same_Object()
        {
            DerivedObject instance = new DerivedObject() { Value = 1 };

            IDependencyContainer container = new DependencyContainer();
            container.Cache(typeof(IBaseInterface), instance);

            instance.Value = 3;

            DerivedObject instanceCache = (DerivedObject) container.Inject<IBaseInterface>();

            Assert.AreEqual(3, instanceCache.Value);
        }

        [Test]
        public void Should_Return_Null()
        {
            IDependencyContainer container = new DependencyContainer();

            Assert.IsNull(container.Inject<IBaseInterface>());
        }

        [Test]
        public void Should_Cache_Null()
        {
            Assert.DoesNotThrow(() => (new DependencyContainer() as IDependencyContainer).Cache(typeof(object), null));
        }

        [Test]
        public void Should_Cache_Derived_Types()
        {
            DerivedObject instance1 = new DerivedObject() { Value = 5 };
            DerivedObject instance2 = new DerivedObject() { Value = 10 };

            IDependencyContainer container = new DependencyContainer();
            container.Cache(typeof(IBaseInterface), instance1);
            container.Cache(typeof(DerivedObject), instance2);

            Assert.AreEqual(5, (container.Inject<IBaseInterface>() as DerivedObject).Value);
            Assert.AreEqual(10, (container.Inject<DerivedObject>()).Value);
        }

        [Test]
        public void Should_Cache_Generic_Types()
        {
            GenericBaseObject<int> instance1 = new GenericBaseObject<int>() { Value = 1 };
            GenericBaseObject<string> instance2 = new GenericBaseObject<string>() { Value = "SomethingHere" };
            GenericBaseObject<double> instance3 = new GenericBaseObject<double>() { Value = 10.5 };

            IDependencyContainer container = new DependencyContainer();
            container.Cache(typeof(GenericBaseObject<int>), instance1);
            container.Cache(typeof(GenericBaseObject<string>), instance2);
            container.Cache(typeof(GenericBaseObject<double>), instance3);

            Assert.AreEqual(1, (container.Inject<GenericBaseObject<int>>()).Value);
            Assert.AreEqual("SomethingHere", (container.Inject<GenericBaseObject<string>>()).Value);
            Assert.AreEqual(10.5, (container.Inject<GenericBaseObject<double>>()).Value);
        }

        [Test]
        public void Should_Return_Parent_Dependency()
        {
            DerivedObject instance = new DerivedObject() { Value = 1 };

            IDependencyContainer parentContainer = new DependencyContainer();
            parentContainer.Cache(typeof(DerivedObject), instance);

            IDependencyContainer container = new DependencyContainer(parentContainer);

            Assert.AreEqual(1, (container.Inject<DerivedObject>()).Value);
        }

        [Test]
        public void Should_Return_All_Dependency()
        {
            IDependencyContainer parentContainer = new DependencyContainer();
            parentContainer.Cache(typeof(DerivedObject), new DerivedObject() { Value = 1 });
            parentContainer.Cache(typeof(DerivedObject), new DerivedObject() { Value = 2 });
            parentContainer.Cache(typeof(DerivedObject), new DerivedObject() { Value = 3 });

            IDependencyContainer container = new DependencyContainer(parentContainer);
            container.Cache(typeof(DerivedObject), new DerivedObject() { Value = 4 });
            container.Cache(typeof(DerivedObject), new DerivedObject() { Value = 5 });

            Assert.AreEqual(5, (container.InjectAll<DerivedObject>()).Count());
        }

        private interface IBaseInterface { }

        private class DerivedObject : IBaseInterface
        {
            public int Value { get; set; }
        }

        private class GenericBaseObject<T>
        {
            public T Value { get; set; }
        }
    }
}
