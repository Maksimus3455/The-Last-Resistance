using Fusion;
using UnityEngine;

namespace Assets.Scripts.Networking.NetworkMovement
{
    public struct NetworkInputData : INetworkInput
    {
        public Vector2 MovementInput;     //здесь будет лежать инпут игрока, который будет передаваться на сервер и обратно через NetworkInputReceiver
        public Vector3 TargetMouseInput;
    }
}
