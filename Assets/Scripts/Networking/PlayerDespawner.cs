using Fusion;
using System;

namespace Fusion_Network_Library
{
    public sealed class PlayerDespawner : SimulationBehaviour
    {
        public event Action<PlayerRef> OnPlayerDespawned;

        /// <summary>
        /// Игрок отсоединился от игры
        /// </summary>
        /// <param name="playerRef">Конктреный игрок, который вышел из сети</param>
        public void DespawnPlayer(PlayerRef playerRef)
        {
            NetworkObject playerObject = Runner.GetPlayerObject(playerRef);

            if (playerObject == null)
                return;

            Runner.SetPlayerObject(playerRef, null);
            Runner.Despawn(playerObject);
            OnPlayerDespawned?.Invoke(playerRef);
        }
    }
}
