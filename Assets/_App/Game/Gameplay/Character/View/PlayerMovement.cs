using System;
using _App.Game.Gameplay.Character.Input;
using UnityEngine;

namespace _App.Game.Gameplay.Character
{
    public class PlayerMovement : MonoBehaviour
    {
        private const float OFFSET_MIN_TOLERANCE = 0.1f;
        private const float OFFSET_ZERO_TOLERANCE = 0f;
        private const float MAX_VALUE = 1f;
        private const float ZERO_VALUE = 0f;
        
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private PlayerInputReader _playerInputReader;
        [SerializeField] private PlayerMovementView _playerMovementView;
        [SerializeField] private float _speed = 1f;

        private Vector2 _moveDirection;
        
        private void OnEnable()
        {
            _playerInputReader.OnMoveAction += HandleMove;
        }

        private void OnDisable()
        {
            _playerInputReader.OnMoveAction -= HandleMove;
        }

        private void HandleMove(Vector2 value)
        {
            if (value.x > OFFSET_MIN_TOLERANCE)
            {
                _moveDirection.x = MAX_VALUE;
            }
            else if (value.x<OFFSET_ZERO_TOLERANCE)
            {
                _moveDirection.x = -MAX_VALUE;
            }
            else
            {
                _moveDirection.x = ZERO_VALUE;
            }

            if (value.y > OFFSET_MIN_TOLERANCE)
            {
                _moveDirection.y = MAX_VALUE;
            }
            else if (value.y < OFFSET_ZERO_TOLERANCE)
            {
                _moveDirection.y = -MAX_VALUE;
            }
            else
            {
                _moveDirection.y = ZERO_VALUE;
            }
        }

        private void FixedUpdate()
        {
            _rigidbody.MovePosition(_rigidbody.position+ _moveDirection * _speed * Time.fixedDeltaTime);
            _playerMovementView.HandleMove(_moveDirection.magnitude>0, _moveDirection);
        }
    }
}
