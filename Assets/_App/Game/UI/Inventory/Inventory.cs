using System;
using System.Collections.Generic;
using _App.Game.Inventory;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _App.Game.UI.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int _slotsNumber = 24;
        public int SlotsNumber => _slotsNumber;
        public InventoryItem[] InventoryItems => _inventoryItems;
        
        [FormerlySerializedAs("_itemsInventory")]
        [Header("Items")]
        [SerializeField] private InventoryItem[] _inventoryItems;
        
        [Inject] private InventoryUI _inventoryUI;

        private void Start()
        {
            _inventoryItems = new InventoryItem[_slotsNumber];
        }

        public void AddItem(InventoryItem itemToAdd, int amountToAdd)
        {
            if (itemToAdd is null)
            {
                return;
            }
            
            //in case there is at least one item of the same type in the inventory
            List<int> indexes = CheckStock(itemToAdd.Id);
            if (itemToAdd.Stackable)
            {
                if (indexes.Count > 0)
                {
                    for (int i = 0; i < indexes.Count; ++i)
                    {
                        if (_inventoryItems[indexes[i]].Amount < itemToAdd.MaxStackAmount)
                        {
                            _inventoryItems[indexes[i]].Amount += amountToAdd;
                            if (_inventoryItems[indexes[i]].Amount > itemToAdd.MaxStackAmount)
                            {
                                int difference = _inventoryItems[indexes[i]].Amount - itemToAdd.MaxStackAmount;
                                _inventoryItems[indexes[i]].Amount = itemToAdd.MaxStackAmount;
                                AddItem(itemToAdd, difference);
                                _inventoryUI.DrawItemOnInventory(itemToAdd, _inventoryItems[indexes[i]].Amount, indexes[i]);
                                return;
                            }
                        }
                    }
                }
            }

            if (amountToAdd <= 0)
            {
                return;
            }

            if (amountToAdd > itemToAdd.MaxStackAmount)
            {
                AddItemInAvailableSlot(itemToAdd, itemToAdd.MaxStackAmount);
                amountToAdd -= itemToAdd.MaxStackAmount;
                AddItem(itemToAdd, amountToAdd);
            }
            else
            {
                AddItemInAvailableSlot(itemToAdd, amountToAdd);
            }
        }

        private List<int> CheckStock(string itemId)
        {
            List<int> itemIndexes = new List<int>();
            for (int index = 0; index < _inventoryItems.Length; index++)
            {
                if (_inventoryItems[index] is not null)
                {
                    if (_inventoryItems[index].Id == itemId)
                    {
                        itemIndexes.Add(index);
                    }
                }
            }
            
            return itemIndexes;
        }

        private void AddItemInAvailableSlot(InventoryItem itemToAdd, int amountToAdd)
        {
            for (int i = 0; i < _inventoryItems.Length; i++)
            {
                if (_inventoryItems[i] is null)
                {
                    _inventoryItems[i] = itemToAdd.DuplicateItem();
                    _inventoryItems[i].Amount = amountToAdd;
                    _inventoryUI.DrawItemOnInventory(itemToAdd, amountToAdd, i);
                    return;
                }
            }
        }
    }
}
