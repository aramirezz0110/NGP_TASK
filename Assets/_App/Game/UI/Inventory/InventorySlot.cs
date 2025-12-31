using System;
using _App.Game.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace _App.Game.UI.Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        public static UnityAction<InteractionType, int> EventSlotInteraction;
        public int Index { get; set; }

        [SerializeField] private Image _iconItem;
        [SerializeField] private GameObject _backgroundAmount;
        [SerializeField] private TMP_Text _amountText;
        
        [Inject] private Inventory _inventory;
        
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

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

        public void ClickSlot()
        {
            EventSlotInteraction?.Invoke(InteractionType.Click, Index);
        }

        public void UseItemSlot()
        {
            if (_inventory.InventoryItems[Index] is not null)
            {
                EventSlotInteraction?.Invoke(InteractionType.Use, Index);
            }
        }

        public void SelectSlot()
        {
            _button.Select();
        }
    }

    public enum InteractionType
    {
        Click,
        Use,
        Equip,
        Remove
    }
}
