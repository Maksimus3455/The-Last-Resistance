using UnityEngine;

namespace Assets.Scripts.Controllers.InputSystemControl
{
    internal class InitInputSystem
    {
        public MainInputSystem MainInputSystem {  get;  }
        public InitInputSystem()
        {
            MainInputSystem = new();
            MainInputSystem.Enable();
            Debug.Log("Инициализация системы ввода");
        }
    }
}
