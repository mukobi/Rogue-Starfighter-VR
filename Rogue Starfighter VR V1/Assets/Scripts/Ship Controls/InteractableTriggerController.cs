using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class InteractableTriggerController : MonoBehaviour
{
    public Interactable interactable;
    public LaserFirer laserFirer;

    // Update is called once per frame
    void Update()
    {
        if (interactable.attachedToHand)
        {
            laserFirer.isTryingToFire = interactable.attachedToHand.uiInteractAction.GetState(interactable.attachedToHand.handType);
        }
        else
        {
            laserFirer.isTryingToFire = false;
        }
    }
}
