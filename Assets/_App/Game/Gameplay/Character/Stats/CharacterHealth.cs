using _App.Game.UI.Inventory;
using UnityEngine;
using Zenject;

namespace _App.Game.Gameplay.Character.Stats
{
    public class CharacterHealth : HealthBase
    {
        public bool CanBeHealed => Health < _maxHealth;
        
        [Inject] private InGameUIManager _uiManager;

        protected override void Start()
        {
            base.Start();
            UpdateHealthBar(Health, _maxHealth);
        }

        public void RestoreHealth(float amount)
        {
            if (CanBeHealed)
            {
                Health += amount;
                if (Health > _maxHealth)
                {
                    Health = _maxHealth;
                }
                UpdateHealthBar(Health, _maxHealth);
            }
        }

        protected override void UpdateHealthBar(float currentHealth, float maxHealth)
        {
            _uiManager.UpdateCharacterHealth(currentHealth, maxHealth);
        }
    }
}
