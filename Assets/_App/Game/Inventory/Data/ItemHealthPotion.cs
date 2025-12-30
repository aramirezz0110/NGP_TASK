using UnityEngine;

namespace _App.Game.Inventory
{
    [CreateAssetMenu(fileName = "New Inventory Item",  menuName = "Inventory Item/Health Potion", order = 0)]
    public class ItemHealthPotion : InventoryItem
    {
        
        [Header("Potion Info")] 
        public float HealthPointsRestauration;
    }
}
