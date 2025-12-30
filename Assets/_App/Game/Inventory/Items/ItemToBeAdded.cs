using System;
using UnityEngine;
using Zenject;

namespace _App.Game.Inventory.Items
{
    public class ItemToBeAdded : MonoBehaviour
    {
        private const string PLAYER_TAG = "Player";
        
        [Header("Config")]
        [SerializeField] private InventoryItem _inventoryItemReference;
        [SerializeField] private int _amountToBeAdded;

        [Inject] private UI.Inventory.Inventory _inventory;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(PLAYER_TAG))
            {
                _inventory.AddItem(_inventoryItemReference, _amountToBeAdded);
                Destroy(gameObject);
            }
        }
    }
}
