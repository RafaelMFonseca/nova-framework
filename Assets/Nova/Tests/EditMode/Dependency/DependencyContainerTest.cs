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
            container.Bind(typeof(IBaseInterface), instance);

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
        public void Should_Bind_Null()
        {
            Assert.DoesNotThrow(() => (new DependencyContainer() as IDependencyContainer).Bind(typeof(object), null));
        }

        [Test]
        public void Should_Bind_Derived_Types()
        {
            DerivedObject instance1 = new DerivedObject() { Value = 5 };
            DerivedObject instance2 = new DerivedObject() { Value = 10 };

            IDependencyContainer container = new DependencyContainer();
            container.Bind(typeof(IBaseInterface), instance1);
            container.Bind(typeof(DerivedObject), instance2);

            Assert.AreEqual(5, (container.Inject<IBaseInterface>() as DerivedObject).Value);
            Assert.AreEqual(10, (container.Inject<DerivedObject>()).Value);
        }

        [Test]
        public void Should_Bind_Generic_Types()
        {
            GenericBaseObject<int> instance1 = new GenericBaseObject<int>() { Value = 1 };
            GenericBaseObject<string> instance2 = new GenericBaseObject<string>() { Value = "SomethingHere" };
            GenericBaseObject<double> instance3 = new GenericBaseObject<double>() { Value = 10.5 };

            IDependencyContainer container = new DependencyContainer();
            container.Bind(typeof(GenericBaseObject<int>), instance1);
            container.Bind(typeof(GenericBaseObject<string>), instance2);
            container.Bind(typeof(GenericBaseObject<double>), instance3);

            Assert.AreEqual(1, (container.Inject<GenericBaseObject<int>>()).Value);
            Assert.AreEqual("SomethingHere", (container.Inject<GenericBaseObject<string>>()).Value);
            Assert.AreEqual(10.5, (container.Inject<GenericBaseObject<double>>()).Value);
        }

        [Test]
        public void Should_Return_Parent_Dependency()
        {
            DerivedObject instance = new DerivedObject() { Value = 1 };

            IDependencyContainer parentContainer = new DependencyContainer();
            parentContainer.Bind(typeof(DerivedObject), instance);

            IDependencyContainer container = new DependencyContainer(parentContainer);

            Assert.AreEqual(1, (container.Inject<DerivedObject>()).Value);
        }

        [Test]
        public void Should_Return_All_Dependency()
        {
            IDependencyContainer parentContainer = new DependencyContainer();
            parentContainer.Bind(typeof(DerivedObject), new DerivedObject() { Value = 1 });
            parentContainer.Bind(typeof(DerivedObject), new DerivedObject() { Value = 2 });
            parentContainer.Bind(typeof(DerivedObject), new DerivedObject() { Value = 3 });

            IDependencyContainer container = new DependencyContainer(parentContainer);
            container.Bind(typeof(DerivedObject), new DerivedObject() { Value = 4 });
            container.Bind(typeof(DerivedObject), new DerivedObject() { Value = 5 });

            Assert.AreEqual(5, (container.InjectAll<DerivedObject>()).Count());
        }

        [Test]
        public void Should_Unbind_Dependency()
        {
            IBaseInterface instance1 = new DerivedObject();
            IBaseInterface instance2 = new DerivedObject();
            IBaseInterface instance3 = new DerivedObject();

            IDependencyContainer parentContainer = new DependencyContainer();
            parentContainer.Bind(typeof(DerivedObject), instance1);
            parentContainer.Bind(typeof(DerivedObject), instance2);

            IDependencyContainer container = new DependencyContainer(parentContainer);
            container.Bind(typeof(DerivedObject), instance3);

            container.Unbind(instance2);

            Assert.AreEqual(2, (container.InjectAll<DerivedObject>()).Count());
            Assert.IsTrue(container.InjectAll<DerivedObject>().All(d => ReferenceEquals(d, instance1) || ReferenceEquals(d, instance3)));
        }

        [Test]
        public void Should_Return_Dependencies_In_Same_Order_As_When_Added()
        {
            IDependencyContainer parentContainer = new DependencyContainer();
            parentContainer.Bind(typeof(IBaseInterface), new OtherDerivedObject() { Value = 20 });

            IDependencyContainer container = new DependencyContainer(parentContainer);
            container.Bind(typeof(IBaseInterface), new DerivedObject() { Value = 10 });
            container.Bind(typeof(IBaseInterface), new OtherDerivedObject() { Value = 20 });

            Assert.IsInstanceOf(typeof(OtherDerivedObject), container.InjectAll<IBaseInterface>().ElementAt(0));
            Assert.IsInstanceOf(typeof(DerivedObject), container.InjectAll<IBaseInterface>().ElementAt(1));
            Assert.IsInstanceOf(typeof(OtherDerivedObject), container.InjectAll<IBaseInterface>().ElementAt(2));
        }

        private interface IBaseInterface { }

        private class DerivedObject : IBaseInterface
        {
            public int Value { get; set; }
        }

        private class OtherDerivedObject : IBaseInterface
        {
            public int Value { get; set; }
        }

        private class GenericBaseObject<T>
        {
            public T Value { get; set; }
        }
    }
}
