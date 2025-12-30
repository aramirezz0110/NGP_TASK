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

        private void UpdateManaBar()
        {
            _uiManager.UpdateCharacterMana(CurrentMana, _maxMana);
        }
    }
}
