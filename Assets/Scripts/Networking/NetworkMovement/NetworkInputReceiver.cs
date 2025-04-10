using Fusion;
using UnityEngine;

namespace Assets.Scripts.Networking.NetworkMovement
{
    internal class NetworkInputReceiver : NetworkBehaviour        //получатель данных с сервера (networkBehavior - аналог монобеха, только на fusion, который
                                                                  //разрабатывает поведение самого игрока, сущности)
    {
        public Vector3 MovementDir;
        public override void FixedUpdateNetwork()
        {
            if (!GetInput(out NetworkInputData inputData)) return;       //получаем инфу с сервера

            Vector2 movementInput = inputData.MovementInput;
            Vector3 movementDirection = new(movementInput.x, 0, movementInput.y);

            MovementDir = movementDirection;                             //получаем инпут в одном месте

        }
    }
}
