using Assets.Scripts.Controllers;
using Fusion;
using Unity.Cinemachine;

namespace Assets.Scripts.Components
{
    internal class CameraFollowComponent : SimulationBehaviour
    {

        private CinemachineCamera FollowCamera { get; set; }

        private void Start()
        {
            FollowCamera = GetComponent<CinemachineCamera>();
        }
        private void OnEnable()
        {
            ReferencesAgregator.Instance.Spawner.OnPlayerSpawned += SetTarget;
        }
        private void OnDisable()
        {
            ReferencesAgregator.Instance.Spawner.OnPlayerSpawned -= SetTarget;
        }

        private void SetTarget(PlayerRef player, NetworkObject gameObj)
        {
           FollowCamera.Target.TrackingTarget = gameObj.transform;
        }

    }
}
