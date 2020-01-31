using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TripleRotationalDrive : MonoBehaviour
{
    private Interactable interactable;

    public Hand.AttachmentFlags attachmentFlags = Hand.AttachmentFlags.DetachFromOtherHand;

    private Quaternion initialHandRotationOnGrab;  // store initial rotation to use as difference // TODO: implement
    private LocalRotateTowardsSlerp LocalRotateTowardsSlerp;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
        LocalRotateTowardsSlerp = GetComponent<LocalRotateTowardsSlerp>();
    }
    protected virtual void OnHandHoverBegin(Hand hand)
    {
        hand.ShowGrabHint();
    }

    protected virtual void OnHandHoverEnd(Hand hand)
    {
        hand.HideGrabHint();
    }
    protected virtual void HandHoverUpdate(Hand hand)
    {
        GrabTypes startingGrabType = hand.GetGrabStarting();

        if (interactable.attachedToHand == null && startingGrabType != GrabTypes.None)
        {
            // was just grabbed
            hand.AttachObject(gameObject, startingGrabType, attachmentFlags);
        }
    }

    protected virtual void HandAttachedUpdate(Hand hand)
    {
        //UpdateLinearMapping(hand.transform);

        if (hand.IsGrabEnding(this.gameObject))
        {
            // just let go
            hand.DetachObject(gameObject);
            LocalRotateTowardsSlerp.TargetRotation = Quaternion.identity;
        }
        else
        {
            // still holding on
            // set target rotation
            // TODO: set based on difference from initial grab rotation
            // TODO: incorporate RestrictRotation inline here instead
            // TODO: scale rotation
            LocalRotateTowardsSlerp.TargetRotation = hand.transform.localRotation;
        }
    }
}
