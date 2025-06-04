using Fusion;
using System;
using UnityEngine;
using Zenject.SpaceFighter;

namespace Fusion_Network_Library
{
    public sealed class PlayerSpawner : SimulationBehaviour    //Simulation - то, что происходит на сцене, а Network - поведение сетевого объекта на сцене
    {
        public event Action<PlayerRef, NetworkObject> OnPlayerSpawned;        //событие, реагирующее на присоединение игрока
        public event Action OnFollowTargetSpawned;
        [SerializeField] private NetworkPrefabRef _playerPrefab;


        private NetworkObject _playerNetworkObj;

        public void SpawnPlayer(PlayerRef playerRef)
        {
            _playerNetworkObj = Runner.Spawn(_playerPrefab, Vector3.zero, Quaternion.identity, playerRef);
            Runner.SetPlayerObject(playerRef, _playerNetworkObj);
            OnPlayerSpawned?.Invoke(playerRef, _playerNetworkObj);
            OnFollowTargetSpawned?.Invoke();
        }
    }
}
