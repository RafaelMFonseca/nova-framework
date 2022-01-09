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
        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("SampleScene");
        }

        [UnityTest]
        public IEnumerator Should_Create_Application_Then_Start_Screen()
        {
            SampleNovaGameApplication application = null;
            SampleNovaGameScreen screen = null;

            GameObject gameObjectApp = null;
            GameObject gameObjectScreen = null;

            Assert.DoesNotThrow(() =>
            {
                gameObjectApp = new GameObject();
                gameObjectApp.name = "Bootstrap";
                application = gameObjectApp.AddComponent<SampleNovaGameApplication>();

                gameObjectScreen = new GameObject();
                gameObjectScreen.name = "ScreenRoot";
                screen = gameObjectScreen.AddComponent<SampleNovaGameScreen>();
            });

            yield return new WaitForFixedUpdate();

            Assert.DoesNotThrow(() =>
            {
                GameObject.Destroy(gameObjectApp);
                GameObject.Destroy(screen);
            });

            yield return new WaitForFixedUpdate();

            Assert.IsTrue(
                   application._startWasCalled
                && application._withSettingsWasCalled
                && application._destroyWasCalled);
        }

        private class SampleNovaGameApplication : MonoBehaviour
        {
            private INovaFrameworkBuilder _application;
            public bool _startWasCalled, _withSettingsWasCalled, _destroyWasCalled;

            public void Start()
            {
                _application = new NovaApplication();

                _application.WithSettings(options =>
                {
                    options.WithScreenFinder(typeof(SceneRootGameObjectsScreenFinder));

                    _withSettingsWasCalled = true;
                });

                _startWasCalled = true;
            }

            public void OnDestroy()
            {
                _application.Dispose();

                _destroyWasCalled = true;
            }
        }

        private class SampleNovaGameScreen : MonoBehaviour, IScreenRoot
        {
            Type IScreenRoot.GetScreenRootType() => typeof(MainMenuScreen);
        }

        private class MainMenuScreen : IScreen, ILoadable, IStartable
        {
            void ILoadable.OnLoad(IDependencyContainer container)
            {
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