using System.Collections.Generic;
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
    }
}
