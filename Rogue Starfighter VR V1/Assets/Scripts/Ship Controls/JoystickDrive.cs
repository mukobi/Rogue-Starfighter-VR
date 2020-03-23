using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class JoystickDrive : BreakableShipSystemAbstract
{
    private Interactable interactable;

    public Hand.AttachmentFlags attachmentFlags = Hand.AttachmentFlags.DetachFromOtherHand;

    [SerializeField] bool changeSlerpWhenGrabbed = false;
    [SerializeField] [Range(0, 1)] float slerpFactorGripped = default;
    [SerializeField] [Range(0, 1)] float slerpFactorReleased = default;

    
    private Quaternion initialHandRotationOnGrab;  // store initial rotation to use as difference // TODO: implement
    private LocalRotateTowardsSlerp LocalRotateTowardsSlerp;

    public override string GetShipSystemName => "Steering System";

    private void Start()
    {
        interactable = GetComponent<Interactable>();
        LocalRotateTowardsSlerp = GetComponent<LocalRotateTowardsSlerp>();
        if(changeSlerpWhenGrabbed)
            LocalRotateTowardsSlerp.slerpFactor = slerpFactorReleased;
    }

    protected virtual void OnHandHoverBegin(Hand hand)
    {
        //hand.ShowGrabHint();
        //Debug.Log("OnHandHoverBegin");
    }

    protected virtual void OnHandHoverEnd(Hand hand)
    {
        //hand.HideGrabHint();
        //Debug.Log("OnHandHoverEnd");
    }

    protected virtual void HandHoverUpdate(Hand hand)
    {
        GrabTypes startingGrabType = hand.GetGrabStarting();

        if (interactable.attachedToHand == null 
            && startingGrabType != GrabTypes.None
            && !shipSystemIsDisabled) // can't grab when steering system disabled
        {
            // was just grabbed
            hand.AttachObject(gameObject, startingGrabType, attachmentFlags);
            initialHandRotationOnGrab = hand.transform.localRotation;
            if (changeSlerpWhenGrabbed)
                LocalRotateTowardsSlerp.slerpFactor = slerpFactorGripped;
        }
    }

    protected virtual void HandAttachedUpdate(Hand hand)
    {
        if (hand.IsGrabEnding(gameObject))
        {
            // just let go
            hand.DetachObject(gameObject);
            LocalRotateTowardsSlerp.TargetRotation = Quaternion.identity;
            if (changeSlerpWhenGrabbed)
                LocalRotateTowardsSlerp.slerpFactor = slerpFactorReleased;
        }
        else
        {
            // still holding on
            // set target rotation
            // TODO: incorporate RestrictRotation inline here instead
            // TODO: scale rotation
            Quaternion relativeRotation = Quaternion.Inverse(initialHandRotationOnGrab) * hand.transform.localRotation;
            LocalRotateTowardsSlerp.TargetRotation = relativeRotation;
        }
    }

    public override void DisableSystem()
    {
        base.DisableSystem();
        // if hand is on the joystick, gtfo
        if (interactable.attachedToHand != null)
        {
            interactable.attachedToHand.DetachObject(gameObject);
        }
    }
}
