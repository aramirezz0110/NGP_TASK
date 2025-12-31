using UnityEngine;

namespace _App.Game.Gameplay.Sounds
{
    public class SFXController : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [Header("Clips")] 
        [SerializeField] private AudioClip _buttonPressed;
        [SerializeField] private AudioClip _itemPicked;
        [SerializeField] private AudioClip _useItem;
        [SerializeField] private AudioClip _removeItem;

        public void PlayButtonPressed()
        {
            _audioSource.PlayOneShot(_buttonPressed);
        }

        public void PlayItemPicked()
        {
            _audioSource.PlayOneShot(_itemPicked);
        }

        public void PlayUseItem()
        {
            _audioSource.PlayOneShot(_useItem);
        }

        public void PlayRemoveItem()
        {
            _audioSource.PlayOneShot(_removeItem);
        }
    }
}