using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Nova.Framework.Core;
using Nova.Framework.Dependency;
using Nova.Framework.Shared;
using Nova.Framework.Entity;
using Nova.Framework.Common.Spawner;
using Nova.Framework.Entity.Component;

namespace Nova.Framework.Tests.Common.Spawner
{
    public class SpawnerControllerTest
    {
        [UnityTest]
        public IEnumerator Should_Spawn_Prefab_Then_Destroy()
        {
            yield return new MonoBehaviourTest<SampleNovaGameApplication>();
        }

        private class SampleNovaGameApplication : MonoBehaviour, IMonoBehaviourTest
        {
            private ISpawnPlayerComponent _spawnPlayerComponent;
            private INovaFrameworkBuilder _application;
            private GameObject _gameObject;

            public bool IsTestFinished => GameObject.Find("Player") != null;

            public void Awake()
            {
                _application = new NovaApplication();

                _application.WithSettings(options =>
                {
                    options.AddSingleton(typeof(ISpawnerController), typeof(SpawnerController));
                });

                _application.Start();
            }

            public void Start()
            {
                _gameObject = new GameObject();
                _spawnPlayerComponent = _gameObject.AddEntity<WorldEntity, ISpawnPlayerComponent>();
                _spawnPlayerComponent.SpawnPlayer();
            }

            public void OnDestroy()
            {
                _application.Dispose();
            }
        }

        private class WorldEntity : EntityGenericBase<SpawnPlayerComponent> { }

        private interface ISpawnPlayerComponent : IComponent
        {
            void SpawnPlayer();
        }

        private class PlayerPrefab : IPrefab
        {
            GameObject IPrefab.Create(IPrefabParameter parameter)
            {
                GameObject player = new GameObject();
                player.name = "Player";

                return player;
            }
        }

        private class SpawnPlayerComponent : ISpawnPlayerComponent, IAwakeable
        {
            private ISpawnerController _spawnerController;

            void IAwakeable.OnAwake(IDependencyContainer container)
            {
                _spawnerController = container.Inject<ISpawnerController>();
            }

            void ISpawnPlayerComponent.SpawnPlayer()
            {
                _spawnerController.Spawn<PlayerPrefab>(new PrefabParameter());
            }
        }
    }
}
