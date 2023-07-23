using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetaFrame.Interaction
{
    public class InteractionSelector : MonoBehaviour
{

    [Tooltip("interaction GameObjects")]
    public InteractionEnabler interactionEnabler;

    // Start is called before the first frame update
    void Start()
    {
        interactionEnabler.InteractionEnable(false);
    }

    public void InteractionActivate() 
    {
        interactionEnabler.InteractionEnable(true);
    }

    public void InteractionDeactivate() 
    {
        interactionEnabler.InteractionEnable(false);
    }
}
}

