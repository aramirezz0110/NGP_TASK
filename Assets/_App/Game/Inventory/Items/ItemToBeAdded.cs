using UnityEngine;

namespace _App.Game.Inventory.Items
{
    public class ItemToBeAdded : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private InventoryItem _inventoryItemReference;
        [SerializeField] private int _amountToBeAdded;
    }
}
