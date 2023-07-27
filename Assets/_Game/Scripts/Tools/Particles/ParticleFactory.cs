using UnityEngine;

namespace CosmicHeart.Tools.Particles
{
    public class ParticleFactory
    {
        // TODO: Оптимизация с использованием пула
        
        public ParticleSystem Create(ParticleSystem prefab)
        {
            return Object.Instantiate(prefab);
        }
    }
}