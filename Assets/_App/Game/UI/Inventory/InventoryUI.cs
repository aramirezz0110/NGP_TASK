using System.Collections.Generic;
using _App.Game.Inventory;
using UnityEngine;
using Zenject;

namespace _App.Game.UI.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private InventorySlot _slotPrefab;
        [SerializeField] private Transform _slotParent;
        
        [Inject] private Inventory _inventory;
        
        private List<InventorySlot> _availableSlots = new List<InventorySlot>();

        private void Start()
        {
            InitializeInventory();
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
    }
}
