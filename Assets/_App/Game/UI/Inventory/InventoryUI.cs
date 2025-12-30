using System;
using System.Collections.Generic;
using _App.Game.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _App.Game.UI.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        [Header("Inventory description panel")]
        [SerializeField] private GameObject _inventoryDescriptionPanel;
        [SerializeField] private Image _iconItem;
        [SerializeField] private TMP_Text _nameItem;
        [SerializeField] private TMP_Text _descriptionItem;
        
        [Header("References")]
        [SerializeField] private InventorySlot _slotPrefab;
        [SerializeField] private Transform _slotParent;
        
        [Inject] private Inventory _inventory;
        
        private List<InventorySlot> _availableSlots = new List<InventorySlot>();

        private void Start()
        {
            InitializeInventory();
        }
        
        private void OnEnable()
        {
            InventorySlot.EventSlotInteraction += SlotInteractionResponse;
        }

        private void OnDisable()
        {
            InventorySlot.EventSlotInteraction -= SlotInteractionResponse;
        }

        private void InitializeInventory()
        {
            for (int index = 0; index < _inventory.SlotsNumber; index++)
            {
                InventorySlot slot = Instantiate(_slotPrefab, _slotParent);
                slot.Index = index;
                _availableSlots.Add(slot);
            }
        }

        public void DrawItemOnInventory(InventoryItem itemToAdd, int amount, int itemIndex)
        {
            InventorySlot slot = _availableSlots[itemIndex];

            if (itemToAdd is not null)
            {
                slot.ActivateSlotUI(true);
                slot.UpdateSlot(itemToAdd, amount);
            }
            else
            {
                slot.ActivateSlotUI(false);
            }
        }

        private void UpdateInventoryDescription(int index)
        {
            bool hasItem = _inventory.InventoryItems[index] is not null;
            
            if (hasItem)
            {
                _iconItem.sprite = _inventory.InventoryItems[index].Icon;
                _nameItem.text = _inventory.InventoryItems[index].Name;
                _descriptionItem.text = _inventory.InventoryItems[index].Description;
            }
            
            _inventoryDescriptionPanel.SetActive(hasItem);
        }

        private void SlotInteractionResponse(InteractionType interactionType, int index)
        {
            if (interactionType == InteractionType.Click)
            {
                UpdateInventoryDescription(index);
            }
        }
    }
}
