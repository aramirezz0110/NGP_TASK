using UnityEngine;

namespace _App.Game.Inventory
{
    [CreateAssetMenu(fileName = "New Inventory Item",  menuName = "Inventory Item/Mana Potion", order = 0)]
    public class ItemManaPotion : InventoryItem
    {
        [Header("Mana Info")] 
        public float ManaPointsRestauration;
    }
}
