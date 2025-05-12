using Fusion;
using Fusion_Network_Library;
using UnityEngine;

namespace Assets.Scripts.Networking.NetworkMovement
{
    internal class InputPopulator : MonoBehaviour
    {
         [SerializeField]private MovementInput _movementInput;
         [SerializeField]private NetworkCallbacksReceiver _callbacksReceiver;

        private void Start()
        {
            _movementInput = GetComponent<MovementInput>();
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
                MovementInput = _movementInput.GetDirection(),
                TargetMouseInput = _movementInput.GetPosition()
            };

            input.Set(inputData);       //команда доставки данных инпута на сервер
        }

    }
}
