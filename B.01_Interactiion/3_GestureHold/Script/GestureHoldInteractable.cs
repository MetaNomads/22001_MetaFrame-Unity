using UnityEngine;
using Oculus.Interaction.HandGrab;

namespace MetaFrame.Interaction
{
    /// <summary>
    /// Use a gesture to hold an interactorable, requires hand grab interactable
    /// issue#1 - multiple interactor in Gesture Hold Interactable - https://github.com/MetaNomads/22001_MetaFrame-Unity/issues/1
    /// </summary>
    public class GestureHoldInteractable : MonoBehaviour
    {
        [SerializeField]
        private HandGrabInteractor _HandGrabInteractor;
        [SerializeField]
        private HandGrabInteractable _HandGrabInteractable;

        public void forceSelect()
        {
            _HandGrabInteractor.ForceSelect(_HandGrabInteractable);
        }

        public void forceRelease()
        {
            _HandGrabInteractor.ForceRelease();
        }




    }
}
