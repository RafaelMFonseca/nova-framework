using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using Nova.Framework.Core;
using Nova.Framework.Dependency;
using Nova.Framework.Controller;
using Nova.Framework.Entity;
using Nova.Framework.Entity.Component;
using Nova.Framework.Common.Coroutine;

namespace Nova.Framework.Tests.Common.Coroutine
{
    public class CoroutineControllerTest
    {
        [UnityTest]
        public IEnumerator Should_Create_Component_Then_Start_Coroutine()
        {
            yield return new MonoBehaviourTest<SampleNovaGameApplication>();
        }

        private class SampleNovaGameApplication : MonoBehaviour, IMonoBehaviourTest
        {
            private INovaFrameworkBuilder _application;
            private GameObject _gameObject;
            private IEntity _entityGenericBase;
            private IChangeGONameComponent _changeGONameComponent;

            public bool IsTestFinished => _gameObject != null && _gameObject.name == "test_name";

            public void Awake()
            {
                _application = new NovaApplication();

                _application.WithSettings(options =>
                {
                    options.AddSingleton(typeof(ICoroutineRunnerController), typeof(CoroutineRunnerController));
                });

                _application.Start();
            }

            public void Start()
            {
                _gameObject = new GameObject();

                _entityGenericBase = _gameObject.AddComponent<ChangeGONameEntity>();

                _changeGONameComponent = _entityGenericBase.OfType<ChangeGONameComponent>().FirstOrDefault();

                _changeGONameComponent.SetName("test_name");
            }

            public void OnDestroy()
            {
                _application.Dispose();
            }
        }

        private class ChangeGONameEntity : EntityGenericBase<ChangeGONameComponent> { }

        private interface IChangeGONameComponent : IComponentHost
        {
            void SetName(string name);
        }

        private class ChangeGONameComponent : IChangeGONameComponent
        {
            private GameObject _host;

            void IComponentHost.SetHost(GameObject host)
            {
                _host = host;
            }

            void IChangeGONameComponent.SetName(string name) => _host.name = name;
        }
    }
}
