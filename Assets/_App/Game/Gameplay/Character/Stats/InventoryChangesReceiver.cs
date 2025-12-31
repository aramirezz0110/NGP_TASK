using System;
using UnityEngine;
using Zenject;

namespace _App.Game.Gameplay.Character.Stats
{
    public class InventoryChangesReceiver : MonoBehaviour
    {
        public static InventoryChangesReceiver Instance;
        
        [Inject] private CharacterHealth _characterHealth;

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
            _characterHealth.RestoreHealth(amount);
        }
    }
}