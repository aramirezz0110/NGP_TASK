using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _App.Game.UI.Inventory
{
    public class InGameUIManager : MonoBehaviour
    {
        private const float FILL_MULTIPLIER = 10f;
        
        [Header("Stats references")]
        [SerializeField] private Image _healthBar;
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private Image _manaBar;
        [SerializeField] private TMP_Text _manaText;
        
        [Header("Panels")]
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameObject _inventoryPanel;
        
        private float _currentHealth;
        private float _maxHealth;
        private float _currentMana;
        private float _maxMana;

        private void Update()
        {
            UpdateCharacterUI();
        }

        public void OpenCloseInventoryPanel()
        {
            _inventoryPanel.SetActive(!_inventoryPanel.activeSelf);
        }
        
        public void OpenClosePausePanel()
        {
            _pausePanel.SetActive(!_pausePanel.activeSelf);
        }

        public void UpdateCharacterHealth(float currentHealthPoints, float maxHealthPoints)
        {
            _currentHealth =  currentHealthPoints;
            _maxHealth = maxHealthPoints;
        }

        public void UpdateCharacterMana(float currentManaPoints, float maxManaPoints)
        {
            _currentMana = currentManaPoints;
            _maxMana = maxManaPoints;
        }

        private void UpdateCharacterUI()
        {
            _healthBar.fillAmount = Mathf.Lerp(
                _healthBar.fillAmount, 
                _currentHealth/_maxHealth, 
                FILL_MULTIPLIER * Time.deltaTime);
            
            _manaBar.fillAmount = Mathf.Lerp(
                _manaBar.fillAmount, 
                _currentMana/_maxMana, 
                FILL_MULTIPLIER * Time.deltaTime);
            
            _healthText.text = $"{_currentHealth}/{_maxHealth}";
            _manaText.text = $"{_currentMana}/{_maxMana}";
        }
    }
}
