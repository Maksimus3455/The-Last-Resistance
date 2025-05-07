using Assets.Scripts.Controllers.InputSystemControl;
using Fusion;
using UnityEngine;

namespace Assets.Scripts.Controllers.MovementControl
{
    internal class NetworkMovementInput : NetworkBehaviour
    {
        [field: SerializeField] private float RotationSpeed { get; set; }
        [field: SerializeField] private float MoveSpeed { get; set; }
        private InitInputSystem InputSystem { get; set; }
        private MovementController Controller { get; set; }

        public override void Spawned()
        {
            InputSystem = new();
            Controller = new();
        }
        public override void FixedUpdateNetwork()
        {
            Controller.PlayerMove(this.gameObject, this.gameObject, InputSystem.MainInputSystem.Player.Move.ReadValue<Vector2>(), MoveSpeed);
            Controller.PlayerRotation(this.gameObject, RotationSpeed);

        }
    }
}
