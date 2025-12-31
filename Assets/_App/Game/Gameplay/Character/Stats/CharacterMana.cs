using _App.Game.UI.Inventory;
using UnityEngine;
using Zenject;

namespace _App.Game.Gameplay.Character.Stats
{
    public class CharacterMana : MonoBehaviour
    {
        [SerializeField] private float _initialMana = 100f;
        [SerializeField] private float _maxMana = 100f;
        [SerializeField] private float _regenerationBySecond;

        public float CurrentMana { get; private set; }
        public bool CanBeRestored => CurrentMana < _maxMana;
        
        [Inject] private InGameUIManager _uiManager;
        
        private void Start()
        {
            CurrentMana = _initialMana;
            UpdateManaBar();
        }

        [ContextMenu("SIMULATE MANA USAGE")]
        public void SimulateManaUsage() => UseMana(10);
        
        public void UseMana(float amount)
        {
            if (CurrentMana >= amount)
            {
                CurrentMana -= amount;
                UpdateManaBar();
            }
        }

        public void RestoreMana(float amount)
        {
            if (CurrentMana >= _maxMana)
            {
                return;
            }
            
            CurrentMana+= amount;
            if (CurrentMana > _maxMana)
            {
                CurrentMana = _maxMana;
            }
            _uiManager.UpdateCharacterMana(CurrentMana, _maxMana);
        }

        private void UpdateManaBar()
        {
            _uiManager.UpdateCharacterMana(CurrentMana, _maxMana);
        }
    }
}
