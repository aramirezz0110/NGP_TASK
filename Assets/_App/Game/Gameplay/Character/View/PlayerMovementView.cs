using _App.Game.Gameplay.Character.Input;
using UnityEngine;

namespace _App.Game.Gameplay.Character
{
    public class PlayerMovementView : MonoBehaviour
    {
        private readonly int X_MOVEMENT_KEY = Animator.StringToHash("xMovement");
        private readonly int Y_MOVEMENT_KEY = Animator.StringToHash("yMovement");
        private const string LAYER_IDLE = "Idle";
        private const string LAYER_WALK = "Walk";
        private const int MAX_LAYER_WEIGHT = 1;
        private const int MIN_LAYER_WEIGHT = 0;
        
        [SerializeField] private Animator _animator;

        
        public void HandleMove(bool isMoving ,Vector2 value)
        {
            UpdateLayers(isMoving);
            if (!isMoving)
            {
                return;
            }
            
            _animator.SetFloat(X_MOVEMENT_KEY, value.x);
            _animator.SetFloat(Y_MOVEMENT_KEY, value.y);
        }

        private void ActivateLayer(string layerName)
        {
            for (int index = 0; index< _animator.layerCount; index++)
            {
                _animator.SetLayerWeight(index, MIN_LAYER_WEIGHT);
            }
            
            _animator.SetLayerWeight(_animator.GetLayerIndex(layerName), MAX_LAYER_WEIGHT);
        }

        private void UpdateLayers(bool value)
        {
            if (value)
            {
                ActivateLayer(LAYER_WALK);
            }
            else
            {
                ActivateLayer(LAYER_IDLE);
            }
        }
    }
}
