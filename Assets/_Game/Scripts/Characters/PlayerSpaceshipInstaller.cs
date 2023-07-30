using CosmicHeart.Controls;
using CosmicHeart.Interactions;
using CosmicHeart.Movement.Moveables;
using UnityEngine;
using Zenject;

namespace CosmicHeart.Characters
{
    public class PlayerSpaceshipInstaller : MonoInstaller
    {
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private ZeroGravityMoveable movement = null;

        public override void InstallBindings()
        {
            BindControls();
            BindMovement();
            BindHealthSystem();
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

        private void BindHealthSystem()
        {
            HealthSystem healthSystem = new HealthSystem(maxHealth);
            Container.Bind<HealthSystem>()
                     .FromInstance(healthSystem)
                     .AsSingle();
        }
    }
}