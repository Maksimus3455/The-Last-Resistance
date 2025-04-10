using Assets.Scripts.Controllers.MovementControl;
using Assets.Scripts.Networking.NetworkMovement;
using Fusion;
using Fusion_Network_Library;
using UnityEngine;

namespace Assets.Scripts.Networking
{
    internal class InputPopulator : MonoBehaviour
    {
        [SerializeField] private MovementInput _movementInput;
        private NetworkCallbacksReceiver _callbacksReceiver;

        private void Awake()
        {
            _callbacksReceiver = GetComponent<NetworkCallbacksReceiver>();
        }

        private void OnEnable()
        {
            _callbacksReceiver.OnPopulateInput += PopulateInput;
        }

        private void OnDisable()
        {
            _callbacksReceiver.OnPopulateInput -= PopulateInput;
        }

        private void PopulateInput(NetworkRunner runner, NetworkInput input)
        {
            NetworkInputData inputData = new()
            {
                MovementInput = _movementInput.GetDirection()
            };

            input.Set(inputData);       //команда доставки данных инпута на сервер
        }
    }
}
