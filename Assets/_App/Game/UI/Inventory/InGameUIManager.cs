using UnityEngine;

namespace _App.Game.UI.Inventory
{
    public class InGameUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameObject _inventoryPanel;

        public void OpenCloseInventoryPanel()
        {
            _inventoryPanel.SetActive(!_inventoryPanel.activeSelf);
        }
        
        public void OpenClosePausePanel()
        {
            _pausePanel.SetActive(!_pausePanel.activeSelf);
        }
    }
}
