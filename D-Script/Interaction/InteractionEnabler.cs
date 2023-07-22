using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MetaFrame.Interaction
{
    public class InteractionEnabler : MonoBehaviour
    {
        [Tooltip("Interaction modules to be activated")]
        public UnityEvent InteractionActivate;
        [Tooltip("Interaction modules to be deactivated")]
        public UnityEvent InteractionDeactivate;

        public void InteractionEnable (bool enable)
        {
            if (enable == true) {InteractionActivate?.Invoke();}
            if (enable == false) {InteractionDeactivate?.Invoke();}
        }


    }
}
