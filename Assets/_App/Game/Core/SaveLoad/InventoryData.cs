using System;
using UnityEngine;

namespace _App.Game.Core.SaveLoad
{
    [Serializable]
    public class InventoryData
    {
        public string[] ItemsData;
        public int[] ItemsAmount;
    }
}
