using _App.Game.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _App.Game.UI.Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        public int Index { get; set; }

        [SerializeField] private Image _iconItem;
        [SerializeField] private GameObject _backgroundAmount;
        [SerializeField] private TMP_Text _amountText;

        public void UpdateSlot(InventoryItem item, int amount)
        {
            _iconItem.sprite = item.Icon;
            _amountText.text = amount.ToString();
        }

        public void ActivateSlotUI(bool state)
        {
            _iconItem.gameObject.SetActive(state);
            _backgroundAmount.SetActive(state);
        }
    }
}
