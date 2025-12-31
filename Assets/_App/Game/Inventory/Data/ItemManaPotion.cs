using _App.Game.Gameplay.Character.Stats;
using UnityEngine;

namespace _App.Game.Inventory
{
    [CreateAssetMenu(fileName = "New Inventory Item",  menuName = "Inventory Item/Mana Potion", order = 0)]
    public class ItemManaPotion : InventoryItem
    {
        [Header("Mana Info")] 
        public float ManaPointsRestauration;
        
        public override bool UseItem()
        {
            if (InventoryChangesReceiver.Instance is not null)
            {
                InventoryChangesReceiver.Instance.RestoreMana(ManaPointsRestauration);
                return true;
            }

            return false;
        }
    }
}
