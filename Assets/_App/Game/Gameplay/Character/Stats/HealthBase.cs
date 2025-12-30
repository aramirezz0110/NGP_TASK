using System;
using UnityEngine;

namespace _App.Game.Gameplay.Character.Stats
{
    public class HealthBase : MonoBehaviour
    {
        [SerializeField] protected float _initialHealth = 100;
        [SerializeField] protected float _maxHealth = 100;

        public float Health { get; protected set; }

        protected virtual void Start()
        {
            Health = _initialHealth;
        }
        
        [ContextMenu("SIMULATE DAMAGE")]
        public void SimulateDamage() => ReceiveDamage(10);

        public void ReceiveDamage(float amount)
        {
            if (amount <= 0)
            {
                return;
            }

            if (Health > 0f)
            {
                Health -= amount;
                UpdateHealthBar(Health, _maxHealth);
                if (Health <= 0f)
                {
                    UpdateHealthBar(Health, _maxHealth);
                    CharacterDefeated();
                }
            }
        }

        protected virtual void UpdateHealthBar(float currentHealth, float maxHealth)
        {
            
        }

        protected virtual void CharacterDefeated()
        {
            
        }
    }
}
