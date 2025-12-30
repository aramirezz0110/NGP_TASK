using UnityEngine;

namespace _App.Game.UI.Inventory
{
    public class InGameUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _inventoryPanel;

        public void OpenCloseInventoryPanel()
        {
            _inventoryPanel.SetActive(!_inventoryPanel.activeSelf);
        }
    }
}
