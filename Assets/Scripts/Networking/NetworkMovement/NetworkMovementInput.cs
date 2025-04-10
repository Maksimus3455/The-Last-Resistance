﻿using Assets.Scripts.Controllers.InputSystemControl;
using Fusion;
using UnityEngine;

namespace Assets.Scripts.Controllers.MovementControl
{
    internal class NetworkMovementInput : NetworkBehaviour
    {

        private NetworkCharacterController NetworkController { get; set; }
        private Camera Camera { get; set; }
        private InitInputSystem InputSystem { get; set; }

        public override void Spawned()
        {
            Camera = Camera.main;
            InputSystem = new();
            NetworkController = GetComponent<NetworkCharacterController>();
        }
        public override void FixedUpdateNetwork()
        {

            NetworkController.Move(GetDirection());
        }

        public Vector3 GetDirection()
        {
            var direction = InputSystem.MainInputSystem.Player.Move.ReadValue<Vector2>();
            Vector3 moveDirection = new Vector3(-direction.y, 0, direction.x) * Runner.DeltaTime;
            return moveDirection;
        }
    }
}
