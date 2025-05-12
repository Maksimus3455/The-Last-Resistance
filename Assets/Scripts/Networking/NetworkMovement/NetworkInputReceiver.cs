using Fusion;
using UnityEngine;

namespace Assets.Scripts.Networking.NetworkMovement
{
    public class NetworkInputReceiver : NetworkBehaviour
    {
        public Vector3 MovementDir;
        public Vector3 MousePosition;
        public override void FixedUpdateNetwork()
        {
            if (!GetInput(out NetworkInputData inputData)) return;       //получаем инфу с сервера

            Vector2 movementInput = inputData.MovementInput;
            Vector3 movementDirection = new(movementInput.x, movementInput.y, 0);
            Vector3 mousePos = inputData.TargetMouseInput;
            MousePosition = mousePos;
            MovementDir = movementDirection;                             //получаем инпут в одном месте

        }

    }
}
