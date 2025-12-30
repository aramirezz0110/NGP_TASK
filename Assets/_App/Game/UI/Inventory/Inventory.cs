using System;
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
    }
}
