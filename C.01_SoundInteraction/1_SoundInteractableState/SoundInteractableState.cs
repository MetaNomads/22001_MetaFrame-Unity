using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using Oculus.Interaction;
using Sirenix.OdinInspector;

namespace MetaFrame.SoundInteraction
{
    public class SoundInteractableState: MonoBehaviour
    {
        public AudioSource _audioSource;

        public UnityEvent isPlayed;
        public UnityEvent isNotPlayed;

        private bool _wasPlaying;

        void Awake()
        {
            // Initialize the events if they are null
            if (isPlayed == null)
            {
                isPlayed = new UnityEvent();
            }
            if (isNotPlayed == null)
            {
                isNotPlayed = new UnityEvent();
            }
        }

        void Update()
        {
            if (_audioSource != null)
            {
                bool isPlaying = _audioSource.isPlaying;

                // Check if the state has changed
                if (isPlaying && !_wasPlaying)
                {
                    // Trigger isPlayed event
                    isPlayed.Invoke();
                }
                else if (!isPlaying && _wasPlaying)
                {
                    // Trigger isNotPlayed event
                    isNotPlayed.Invoke();
                }

                // Update the previous state
                _wasPlaying = isPlaying;
            }
        }
    }
}