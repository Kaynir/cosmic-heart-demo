using System;
using UnityEngine;

namespace CosmicHeart.Interactions
{
    public class HealthSystem
    {
        private const int MIN_VALUE = 0;

        public event Action<int, int> ValueChanged;
        public event Action ValueDepleted;
        
        public int Value { get; private set; }
        public int MaxValue { get; private set; }

        public HealthSystem(int maxValue)
        {
            MaxValue = maxValue;
            SetValue(maxValue);
        }

        public void SetValue(int value)
        {
            Value = Mathf.Clamp(value, MIN_VALUE, MaxValue);
            ValueChanged?.Invoke(Value, MaxValue);

            if (Value == MIN_VALUE) ValueDepleted?.Invoke();
        }

        public void UpdateValue(int amount)
        {
            SetValue(Value + amount);
        }
    }
}