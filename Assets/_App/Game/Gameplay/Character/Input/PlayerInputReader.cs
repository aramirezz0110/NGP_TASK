using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace _App.Game.Gameplay.Character.Input
{
    public class PlayerInputReader : MonoBehaviour
    {
        public UnityAction<Vector2> OnMove;
        
        [SerializeField] private InputActionReference _movement;

        private void OnEnable()
        {
            _movement.action.performed += OnMovePerformed;
            _movement.action.canceled += OnMoveCanceled;
        }
        
        private void OnDisable()
        {
            _movement.action.performed -= OnMovePerformed;
            _movement.action.canceled -= OnMoveCanceled;
        }

        private void OnMovePerformed(InputAction.CallbackContext obj)
        {
            OnMove?.Invoke(obj.ReadValue<Vector2>());
        }
        
        private void OnMoveCanceled(InputAction.CallbackContext obj)
        {
            OnMove?.Invoke(Vector2.zero);
        }
    }
}
