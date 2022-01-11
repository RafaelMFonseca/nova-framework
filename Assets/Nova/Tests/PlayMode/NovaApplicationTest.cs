using System;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using Nova.Framework.Screen;
using Nova.Framework.Core;
using Nova.Framework.Dependency;
using Nova.Framework.Controller;

namespace Nova.Framework.Tests
{
    public class NovaApplicationTest
    {
        [UnityTest]
        public IEnumerator Should_Create_Application_Then_Start_Screen()
        {
            yield return new MonoBehaviourTest<SampleNovaGameApplication>();
        }

        private interface IWeatherController { }

        private class WeatherController : IWeatherController, IController { }

        private class SampleNovaGameApplication : MonoBehaviour, IMonoBehaviourTest
        {
            private INovaFrameworkBuilder _application;

            public bool IsTestFinished => true;

            public void Start()
            {
                _application = new NovaApplication();

                _application.WithSettings(options =>
                {
                    options.WithScreenFinder(typeof(SceneRootGameObjectsScreenFinder));
                    options.AddSingleton(typeof(IWeatherController), typeof(WeatherController));
                });

                _application.Start();
            }

            public void OnDestroy()
            {
                _application.Dispose();
            }
        }

        private class SampleNovaGameScreen : MonoBehaviour, IScreenRoot
        {
            Type IScreenRoot.GetScreenRootType() => typeof(MainMenuScreen);
        }

        private class MainMenuScreen : IScreen, ILoadable, IStartable
        {
            private IWeatherController _weatherController;

            void ILoadable.OnLoad(IDependencyContainer container)
            {
                _weatherController = container.Inject<IWeatherController>();
            }

            void IStartable.OnStart()
            {

            }
        }

        //private class RandomGameObject : MonoBehaviour, IModel, ILoadable, IStartable, IUpdateable
        //{
        //    void ILoadable.OnLoad(IDependencyContainer container) { }

        //    void IModel.CreateGameObject()
        //    {

        //    }

        //    void IStartable.OnStart() { }

        //    void IUpdateable.OnUpdate() { }

        //    void IUpdateable.OnLateUpdate() { }
        //}
    }
}