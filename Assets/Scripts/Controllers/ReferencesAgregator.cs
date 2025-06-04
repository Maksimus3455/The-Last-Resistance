using Fusion_Network_Library;
using Zenject;

namespace Assets.Scripts.Controllers
{
    public class ReferencesAgregator
    {
        public static ReferencesAgregator Instance { get; private set; }    

        public PlayerSpawner Spawner { get; private set; }

        public ReferencesAgregator()
        {
            Instance = this;
        }

        [Inject]
        public void Construct(PlayerSpawner spawner)
        {
            Spawner = spawner;
        }
    }
}
