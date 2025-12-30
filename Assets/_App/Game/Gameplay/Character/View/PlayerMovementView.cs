using System;
using _App.Game.Gameplay.Character.Input;
using UnityEngine;

namespace _App.Game.Gameplay.Character
{
    public class PlayerMovementView : MonoBehaviour
    {
        private readonly int xMovementKey = Animator.StringToHash("xMovement");
        private readonly int yMovementKey = Animator.StringToHash("yMovement");
        
        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerInputReader _playerInputReader;
        
        private void OnEnable()
        {
            _playerInputReader.OnMove += HandleMove;
        }

        private void OnDisable()
        {
            _playerInputReader.OnMove -= HandleMove;
        }
        
        private void HandleMove(Vector2 value)
        {
            _animator.SetFloat(xMovementKey, value.x);
            _animator.SetFloat(yMovementKey, value.y);
        }
    }
}
