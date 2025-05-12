using Fusion;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

namespace Fusion_Network_Library
{
    public sealed class FusionStartSimulation : MonoBehaviour
    {
        private NetworkSceneManagerDefault _networkScene;
        private NetworkRunner _runner;                           //ядро, основной класс сетевого кода
        private string _sessionName = "SampleSession";

        private void Start()
        {
            _networkScene = GetComponent<NetworkSceneManagerDefault>();
            _runner = GetComponent<NetworkRunner>();
            StartSimulation(GameMode.AutoHostOrClient);
        }

        /// <summary>
        /// Запуск симуляции на сервере
        /// </summary>
        /// <param name="gameMode"></param>
        private async void StartSimulation(GameMode gameMode)
        {
            _runner.ProvideInput = true;

            await _runner.StartGame(new StartGameArgs                           //Стартовые параметры для запуска симуляции
            {
                GameMode = gameMode,
                SceneManager = _networkScene,
                Scene = GetScene(),
                SessionName = _sessionName
            });
        }

        public void StartHostMigration(HostMigrationToken hostMigrationToken)
        {
            _runner = GetComponent<NetworkRunner>();
            InitializeNetworkRunnerHostMigration(_runner, hostMigrationToken);
            Debug.Log("Миграция хоста запустилась");
        }

        public async void InitializeNetworkRunnerHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {
            _runner.ProvideInput = true;
            await runner.StartGame(new StartGameArgs
            {
                SceneManager = _networkScene,
                HostMigrationToken = hostMigrationToken,
                HostMigrationResume = HostMigrationResume
            });
        }

        private void HostMigrationResume(NetworkRunner runner)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Присваивание обычной сцены сетевой
        /// </summary>
        /// <returns>Сетевая сцена</returns>
        private SceneRef GetScene()
        {
            int buildIndex = SceneManager.GetActiveScene().buildIndex;
            return SceneRef.FromIndex(buildIndex);
        }
    }
}
