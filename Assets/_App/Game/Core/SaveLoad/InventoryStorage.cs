using _App.Game.Inventory;
using UnityEngine;

namespace _App.Game.Core.SaveLoad
{
    [CreateAssetMenu(menuName = "Inventory/Storage", fileName = "New Inventory Storage")]
    public class InventoryStorage : ScriptableObject
    {
        public InventoryItem[] Items;
    }
}
