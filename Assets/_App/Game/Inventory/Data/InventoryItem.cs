using System;
using UnityEngine;

namespace _App.Game.Inventory
{
    [CreateAssetMenu(fileName = "New Inventory Item",  menuName = "Inventory Item/Generic", order = 0)]
    public class InventoryItem : ScriptableObject
    {
        [Header("Parameters")] 
        public string Id;
        public string Name;
        [TextArea] public string Description;
        public Sprite Icon;

        [Header("Information")] 
        public ItemType Type;
        public bool Consumable;
        public bool Stackable;
        public int MaxStackAmount;

        [HideInInspector] public int Amount;
        //public int Amount;

        public InventoryItem DuplicateItem()
        {
            return Instantiate(this);
        }
    }

    public enum ItemType
    {
        Weapon,
        Potion,
        Parchment,
        Ingredient,
        Treasure
    }
}
