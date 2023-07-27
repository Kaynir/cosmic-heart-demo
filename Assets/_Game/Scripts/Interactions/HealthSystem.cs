using System;
using UnityEngine;

namespace CosmicHeart.Interactions
{
    public class HealthSystem : MonoBehaviour, IDamageable
    {
        private const int MIN_VALUE = 0;
        private const int DEFAULT_MAX = 1;

        public event Action<int, int> ValueChanged;
        public event Action Died;

        [SerializeField, Min(DEFAULT_MAX)] private int maxValue = DEFAULT_MAX;

        public int Value { get; private set; }

        private void OnEnable() => SetValue(maxValue);

        public void TakeDamage(int amount)
        {
            SetValue(Value - amount);
        }

        private void SetValue(int value)
        {
            Value = Mathf.Clamp(value, MIN_VALUE, maxValue);
            ValueChanged?.Invoke(Value, maxValue);

            if (Value > MIN_VALUE) return;
            Died?.Invoke();
        }
    }
}