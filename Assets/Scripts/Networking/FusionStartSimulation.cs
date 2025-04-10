using Fusion;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Fusion_Network_Library
{
    public sealed class FusionStartSimulation : MonoBehaviour
    {
        [SerializeField] private NetworkSceneManagerDefault _networkScene;
        [SerializeField] private NetworkRunner _runner;                           //ядро, основной класс сетевого кода
        private string _sessionName = "SampleSession";

        private void Start()
        {
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
        /// <summary>
        ///  Присваивание обычной сцены сетевой
        /// </summary>
        /// <returns></returns>
        private SceneRef GetScene()
        {
            int buildIndex = SceneManager.GetActiveScene().buildIndex;
            return SceneRef.FromIndex(buildIndex);
        }

    }
}
