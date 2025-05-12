using Assets.Scripts.Networking.NetworkMovement;
using Fusion;
using UnityEngine;

namespace Assets.Scripts.Controllers.MovementControl
{
    internal class NetworkMovementInput : NetworkBehaviour
    {
        [field: SerializeField] private float RotationSpeed { get; set; }
        [field: SerializeField] private float MoveSpeed { get; set; }
        private NetworkInputReceiver Receiver {get; set; }
        //private InitInputSystem InputSystem { get; set; }
        private MovementController Controller { get; set; }

        public override void Spawned()
        {
            //InputSystem = new();
            Controller = new();
            Receiver = GetComponent<NetworkInputReceiver>();
        }
        public override void FixedUpdateNetwork()
        {
            Controller.PlayerMove(this.gameObject, this.gameObject, Receiver.MovementDir, MoveSpeed);
            Controller.PlayerRotation(this.gameObject, RotationSpeed, Receiver.MousePosition);

        }
    }
}
