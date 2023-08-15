using System.Collections;
using System.Collections.Generic;
using CosmicHeart.Controls;
using UnityEngine;
using Zenject;

namespace CosmicHeart.Core.Installers
{
    public class PersistentInstaller : MonoInstaller
    {
        [SerializeField] private PlayerControls playerControls;

        public override void InstallBindings()
        {
            InstallPlayerInputs();
        }

        public void InstallPlayerInputs()
        {
            Container.BindInterfacesAndSelfTo<PlayerControls>()
                     .FromInstance(playerControls)
                     .AsSingle();
        }
    }
}