using System;
using UnityEngine;
using Zenject;

namespace _App.Game.Gameplay.Character.Stats
{
    public class InventoryChangesReceiver : MonoBehaviour
    {
        public static InventoryChangesReceiver Instance;
        
        [Inject] private CharacterHealth _characterHealth;
        [Inject] private CharacterMana _characterMana;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        public void RestoreHealth(float amount)
        {
            if (_characterHealth.CanBeHealed)
            {
                _characterHealth.RestoreHealth(amount);
            }
        }

        public void RestoreMana(float amount)
        {
            if (_characterMana.CanBeRestored)
            {
                _characterMana.RestoreMana(amount);
            }
        }
    }
}