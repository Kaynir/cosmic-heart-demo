using CosmicHeart.Characters;
using CosmicHeart.Controls;
using CosmicHeart.Interactions;
using CosmicHeart.Movement.Moveables;
using UnityEngine;
using Zenject;

public class PlayerSpaceshipInstaller : MonoInstaller
{
    [Header("Required Instances:")]
    [SerializeField] private ZeroGravityMoveable movement = null;
    [SerializeField] private HealthSystem healthSystem = null;

    public override void InstallBindings()
    {
        BindControls();
        BindMovement();
    }

    private void BindControls()
    {
        Container.Bind<PlayerInputActions>().AsSingle();
        Container.BindInterfacesTo<PlayerControls>().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerFacade>().AsSingle();
    }

    private void BindMovement()
    {
        Container.BindInterfacesTo<ZeroGravityMoveable>()
                 .FromInstance(movement)
                 .AsSingle();
    }
}