using System;
using System.Collections.Generic;
using _App.Game.Inventory;
using UnityEngine;

namespace _App.Game.UI.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int _slotsNumber = 24;
        public int SlotsNumber => _slotsNumber;
        
        [Header("Items")]
        [SerializeField] private InventoryItem[] _itemsInventory;

        private void Start()
        {
            _itemsInventory = new InventoryItem[_slotsNumber];
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
                        if (_itemsInventory[indexes[i]].Amount < itemToAdd.MaxStackAmount)
                        {
                            _itemsInventory[indexes[i]].Amount += amountToAdd;
                            if (_itemsInventory[indexes[i]].Amount > itemToAdd.MaxStackAmount)
                            {
                                int difference = _itemsInventory[indexes[i]].Amount - itemToAdd.MaxStackAmount;
                                _itemsInventory[indexes[i]].Amount = itemToAdd.MaxStackAmount;
                                AddItem(itemToAdd, difference);
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
            for (int index = 0; index < _itemsInventory.Length; index++)
            {
                if (_itemsInventory[index] is not null)
                {
                    if (_itemsInventory[index].Id == itemId)
                    {
                        itemIndexes.Add(index);
                    }
                }
            }
            
            return itemIndexes;
        }

        private void AddItemInAvailableSlot(InventoryItem itemToAdd, int amountToAdd)
        {
            for (int i = 0; i < _itemsInventory.Length; i++)
            {
                if (_itemsInventory[i] is null)
                {
                    _itemsInventory[i] = itemToAdd.DuplicateItem();
                    _itemsInventory[i].Amount = amountToAdd;
                    return;
                }
            }
        }
    }
}
