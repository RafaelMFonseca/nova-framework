using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Nova.Framework.Core;
using Nova.Framework.Dependency;
using Nova.Framework.Shared;
using Nova.Framework.Entity;
using Nova.Framework.Entity.Component;
using Nova.Framework.Common.Coroutiner;

namespace Nova.Framework.Tests.Common.Coroutiner
{
    public class CoroutinerControllerTest
    {
        [UnityTest]
        public IEnumerator Should_Create_Component_Then_Start_Coroutine()
        {
            yield return new MonoBehaviourTest<SampleNovaGameApplication>();
        }

        private class SampleNovaGameApplication : MonoBehaviour, IMonoBehaviourTest
        {
            private IChangeGONameComponent _changeGONameComponent;
            private INovaFrameworkBuilder _application;
            private GameObject _gameObject;

            public bool IsTestFinished => _gameObject != null && _gameObject.name == "test_name";

            public void Awake()
            {
                _application = new NovaApplication();

                _application.WithSettings(options =>
                {
                    options.AddSingleton(typeof(ICoroutinerController), typeof(CoroutinerController));
                });

                _application.Start();
            }

            public void Start()
            {
                _gameObject = new GameObject();

                _changeGONameComponent = _gameObject.AddEntity<ChangeGONameEntity, IChangeGONameComponent>();
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

        private class ChangeGONameComponent : IChangeGONameComponent, IAwakeable
        {
            private ICoroutinerController _coroutinerController;
            private GameObject _host;

            void IComponentHost.SetHost(GameObject host)
            {
                _host = host;
            }

            void IAwakeable.OnAwake(IDependencyContainer container)
            {
                _coroutinerController = container.Inject<ICoroutinerController>();
            }

            void IChangeGONameComponent.SetName(string name)
            {
                _coroutinerController.Start(SetNameAsync(name));
            }

            IEnumerator SetNameAsync(string name)
            {
                yield return null;

                _host.name = name;

                yield return null;
            }
        }
    }
}
