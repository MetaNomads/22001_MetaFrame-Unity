using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MetaFrame.ArchInteraction
{
    public class SpaceInteractableState : MonoBehaviour
    {
        [Tooltip("The colliders used as the trigger areas.")]
        public List<Collider> triggerColliders;

        [SerializeField] private UnityEvent whenEnter;
        [SerializeField] private UnityEvent whenLeave;

        private HashSet<Collider> collidersInSpace = new HashSet<Collider>(); // To keep track of colliders currently in the space
        private bool isTriggered = false; // To track if the enter event has been triggered

        private void OnTriggerEnter(Collider other)
        {
            if (triggerColliders.Contains(other))
            {
                collidersInSpace.Add(other);

                if (!isTriggered)
                {
                    isTriggered = true;
                    whenEnter.Invoke();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (triggerColliders.Contains(other))
            {
                collidersInSpace.Remove(other);

                if (collidersInSpace.Count == 0 && isTriggered)
                {
                    isTriggered = false;
                    whenLeave.Invoke();
                }
            }
        }
    }
}