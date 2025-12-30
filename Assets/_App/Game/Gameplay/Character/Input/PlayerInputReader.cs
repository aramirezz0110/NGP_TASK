using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace _App.Game.Gameplay.Character.Input
{
    public class PlayerInputReader : MonoBehaviour, PlayerInputSystemActions.IPlayerActions
    {
        public UnityAction<Vector2> OnMoveAction;
        
        private PlayerInputSystemActions _playerInputSystemActions;

        private void Awake()
        {
            _playerInputSystemActions = new PlayerInputSystemActions();
            _playerInputSystemActions.Player.SetCallbacks(this);
        }

        private void OnEnable()
        {
            _playerInputSystemActions.Enable();
        }

        private void OnDisable()
        {
            _playerInputSystemActions.Disable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            // if (context.performed)
            // {
            //     OnMoveAction?.Invoke(context.ReadValue<Vector2>());
            // }
            // else if(context.canceled)
            // {
            //     OnMoveAction?.Invoke(Vector2.zero);
            // }
            OnMoveAction?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnLook(InputAction.CallbackContext context)
        {
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
        }

        public void OnCrouch(InputAction.CallbackContext context)
        {
        }

        public void OnJump(InputAction.CallbackContext context)
        {
        }

        public void OnPrevious(InputAction.CallbackContext context)
        {
        }

        public void OnNext(InputAction.CallbackContext context)
        {
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
        }
    }
}
