using System;
using System.Collections.Generic;
using _App.Game.Core.SaveLoad;
using _App.Game.Inventory;
using BayatGames.SaveGameFree;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _App.Game.UI.Inventory
{
    public class Inventory : MonoBehaviour
    {
        private const string INVENTORY_KEY = "InventorySaving2026";
        
        public int SlotsNumber => _slotsNumber;
        public InventoryItem[] InventoryItems => _inventoryItems;
        
        [SerializeField] private int _slotsNumber = 24;
        [Header("Items")]
        [SerializeField] private InventoryStorage _inventoryStorage;
        [SerializeField] private InventoryItem[] _inventoryItems;
        [SerializeField] private InventoryData _dataSave;
        [SerializeField] private InventoryData _dataLoaded; 
        
        [Inject] private InventoryUI _inventoryUI;

        private void Start()
        {
            _inventoryItems = new InventoryItem[_slotsNumber];
            Debug.Log($"items {_inventoryItems.Length} / slot {_slotsNumber}");
            LoadInventory();
        }

        private void OnEnable()
        {
            InventorySlot.EventSlotInteraction += SlotInteractionResponse;
        }

        private void OnDisable()
        {
            InventorySlot.EventSlotInteraction -= SlotInteractionResponse;
        }

        private void SlotInteractionResponse(InteractionType interactionType, int index)
        {
            Debug.Log($"interaction type: {interactionType}");
            switch (interactionType)
            {
                case InteractionType.Use: UseItem(index); break;
                case InteractionType.Equip: break;
                case InteractionType.Remove:RemoveItem(index); break;
            }
        }

        private void UseItem(int index)
        {
            if (_inventoryItems[index] is null)
            {
                return;
            }

            if (_inventoryItems[index].UseItem())
            {
                DeleteItem(index);
            }
        }

        private void DeleteItem(int index)
        {
            InventoryItems[index].Amount--;
            if (_inventoryItems[index].Amount <= 0)
            {
                _inventoryItems[index].Amount = 0;
                _inventoryItems[index] = null;
                _inventoryUI.DrawItemOnInventory(null, 0, index);
            }
            else
            {
                _inventoryUI.DrawItemOnInventory(_inventoryItems[index], _inventoryItems[index].Amount, index);
            }
            SaveInventory();
        }

        private void RemoveItem(int index)
        {
            Debug.Log("Removing item");
            if (_inventoryItems[index] is null)
            {
                return;
            }
            
            _inventoryItems[index].Amount = 0;
            _inventoryItems[index] = null;
            _inventoryUI.DrawItemOnInventory(null, 0, index);
            
            SaveInventory();
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
            
            SaveInventory();
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

        private InventoryItem ItemExistsOnStorage(string itemId)
        {
            for (int i = 0; i < _inventoryStorage.Items.Length; i++)
            {
                if (_inventoryStorage.Items[i].Id == itemId)
                {
                    return _inventoryStorage.Items[i];
                }
            }

            return null;
        }

        #region Saving

        private void SaveInventory()
        {
            _dataSave = new InventoryData();
            _dataSave.ItemsData = new string[_slotsNumber];
            _dataSave.ItemsAmount = new int[_slotsNumber];

            for (int i = 0; i < _slotsNumber; i++)
            {
                if (_inventoryItems[i] is null || string.IsNullOrEmpty(_inventoryItems[i].Id))
                {
                    _dataSave.ItemsData[i] = null;
                    _dataSave.ItemsAmount[i] = 0;
                }
                else
                {
                    _dataSave.ItemsData[i] = _inventoryItems[i].Id;
                    _dataSave.ItemsAmount[i] = _inventoryItems[i].Amount;
                }
            }
            
            SaveGame.Save(INVENTORY_KEY, _dataSave);
        }

        private void LoadInventory()
        {
            if (SaveGame.Exists(INVENTORY_KEY))
            {
                _dataLoaded = SaveGame.Load<InventoryData>(INVENTORY_KEY);
                Debug.Log($"data loaded: {_dataLoaded.ItemsAmount.Length} {_dataLoaded.ItemsData.Length}");
                for (int i = 0; i < _slotsNumber; i++)
                {
                    if (_dataLoaded.ItemsData[i] is not null)
                    {
                        InventoryItem itemStorage = ItemExistsOnStorage(_dataLoaded.ItemsData[i]);
                        if (itemStorage is not null)
                        {
                            _inventoryItems[i] = itemStorage.DuplicateItem();
                            _inventoryItems[i].Amount = _dataLoaded.ItemsAmount[i];
                            _inventoryUI.DrawItemOnInventory(_inventoryItems[i], _inventoryItems[i].Amount, i);
                        }
                    }
                    else
                    {
                        _inventoryItems[i] = null;
                    }
                }
            }
        }

        #endregion
    }
}
