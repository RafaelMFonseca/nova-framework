using System;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using Nova.Framework.Core;
using Nova.Framework.Dependency;
using Nova.Framework.Controller;
using Nova.Framework.Entity;
using Nova.Framework.Entity.Component;

namespace Nova.Framework.Tests
{
    public class NovaApplicationTest
    {
        [UnityTest]
        public IEnumerator Should_Create_Application_Then_Start_Screen()
        {
            yield return new MonoBehaviourTest<SampleNovaGameApplication>();
        }

        private interface IWeatherController : IController { }

        private class WeatherController : IWeatherController { }

        private class SampleNovaGameApplication : MonoBehaviour, IMonoBehaviourTest
        {
            private INovaFrameworkBuilder _application;

            public bool IsTestFinished => true;

            public void Start()
            {
                _application = new NovaApplication();

                _application.WithSettings(options =>
                {
                    options.AddSingleton(typeof(IWeatherController), typeof(WeatherController));
                });

                _application.Start();
            }

            public void OnDestroy()
            {
                _application.Dispose();
            }
        }

        private class WorldComponent_Entity : EntityBase
        {
            private IWorldComponent worldComponent = new WorldComponent();

            public override IComponent[] GetComponents() => new[] { worldComponent };
        }

        private interface IWorldComponent : IComponent { }

        private class WorldComponent : IWorldComponent, IStartable, IUpdateable, IDestroyable, ILoadable
        {
            void ILoadable.OnPreLoad(IDependencyContainer container) { }

            void ILoadable.OnLoad(IDependencyContainer container) { }

            void IStartable.OnAwake() { }

            void IStartable.OnStart() { }

            void IUpdateable.OnUpdate() { }

            void IUpdateable.OnLateUpdate() { }

            void IDestroyable.OnDestroy() { }
        }
    }
}