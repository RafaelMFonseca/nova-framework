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
        public IEnumerator Should_Create_Application_Then_Start_Component()
        {
            yield return new MonoBehaviourTest<SampleNovaGameApplication>();
        }

        private class SampleApplicationResult
        {
            public bool onPreLoad, onLoad, onAwake, onStart, onUpdate, onLateUpdate, onDestroy, onEnable, onDisable = false;
        }

        private interface IWeatherController : IController { }

        private class WeatherController : IWeatherController { }

        private class SampleNovaGameApplication : MonoBehaviour, IMonoBehaviourTest
        {
            private INovaFrameworkBuilder _application;
            private WorldComponent_Entity _worldComponentEntity;
            private GameObject _worldComponentGO;
            private SampleApplicationResult _sampleApplicationResult;

            public bool IsTestFinished =>
                   _sampleApplicationResult != null
                && _sampleApplicationResult.onPreLoad
                && _sampleApplicationResult.onLoad
                && _sampleApplicationResult.onAwake
                && _sampleApplicationResult.onStart
                /* && _sampleApplicationResult.onUpdate
                && _sampleApplicationResult.onLateUpdate */
                && _sampleApplicationResult.onEnable
                && _sampleApplicationResult.onDisable
                && _sampleApplicationResult.onDestroy;

            public void Awake()
            {
                _application = new NovaApplication();

                _application.WithSettings(options =>
                {
                    options.AddSingleton(typeof(IWeatherController), typeof(WeatherController));
                });

                _application.Start();
            }

            public void Start()
            {
                _worldComponentGO = new GameObject();
                _worldComponentEntity = _worldComponentGO.AddComponent<WorldComponent_Entity>();
                _sampleApplicationResult = _worldComponentEntity.sampleApplicationResult;
                StartCoroutine(DestroyAfterSeconds(0.1f));
            }

            public IEnumerator DestroyAfterSeconds(float seconds)
            {
                yield return null;

                yield return new WaitForSeconds(seconds);

                _worldComponentEntity.enabled = false;

                yield return null;

                yield return new WaitForSeconds(seconds);

                Destroy(_worldComponentGO);

                _worldComponentGO = null;

                yield return null;
            }

            public void OnDestroy()
            {
                _application.Dispose();
            }
        }

        private class WorldComponent_Entity : EntityBase
        {
            public SampleApplicationResult sampleApplicationResult = new SampleApplicationResult();

            public override IComponent[] GetComponents()
            {
                return new[] { new WorldComponent(this, sampleApplicationResult) };
            }
        }

        private interface IWorldComponent : IComponent { }

        private class WorldComponent : IWorldComponent, IStartable, IUpdateable, IDestroyable, IEnableable, ILoadable
        {
            private WorldComponent_Entity _worldComponentEntity;
            private SampleApplicationResult _sampleApplicationResult;

            public WorldComponent(WorldComponent_Entity entity, SampleApplicationResult sampleApplicationResult)
            {
                _worldComponentEntity = entity;
                _sampleApplicationResult = sampleApplicationResult;
            }

            void ILoadable.OnPreLoad(IDependencyContainer container) => _sampleApplicationResult.onPreLoad = true;

            void ILoadable.OnLoad(IDependencyContainer container) => _sampleApplicationResult.onLoad = true;

            void IStartable.OnAwake() => _sampleApplicationResult.onAwake = true;

            void IStartable.OnStart() => _sampleApplicationResult.onStart = true;

            void IUpdateable.OnUpdate() => _sampleApplicationResult.onUpdate = true;

            void IUpdateable.OnLateUpdate() => _sampleApplicationResult.onLateUpdate = true;

            void IEnableable.OnEnable() => _sampleApplicationResult.onEnable = true;

            void IEnableable.OnDisable() => _sampleApplicationResult.onDisable = true;

            void IDestroyable.OnDestroy() => _sampleApplicationResult.onDestroy = true;
        }
    }
}