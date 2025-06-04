using Assets.Scripts.Controllers;
using Fusion_Network_Library;
using UnityEngine;
using Zenject;

public class GamePlayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ReferencesAgregator>().AsSingle().NonLazy();
        Container.Bind<PlayerSpawner>().FromComponentInHierarchy().AsSingle();
    }
}
