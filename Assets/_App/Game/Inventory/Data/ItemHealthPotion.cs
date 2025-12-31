using _App.Game.Gameplay.Character.Stats;
using UnityEngine;
using Zenject;

namespace _App.Game.Inventory
{
    [CreateAssetMenu(fileName = "New Inventory Item",  menuName = "Inventory Item/Health Potion", order = 0)]
    public class ItemHealthPotion : InventoryItem
    {
        [Header("Potion Info")] 
        public float HealthPointsRestauration;
        
        public override bool UseItem()
        {
            if (InventoryChangesReceiver.Instance is not null)
            {
                InventoryChangesReceiver.Instance.RestoreHealth(HealthPointsRestauration);
                return true;
            }

            return false;
        }
    }
}
