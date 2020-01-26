using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ResetPlayAreaTransform : MonoBehaviour
{
    [SerializeField] Transform hmd = default;

    [SerializeField] Transform playArea = default;

    [SerializeField] Transform targetHeadsetTransform = default;

    [SerializeField] SteamVR_Action_Boolean resetPositionAction = default;

    // Update is called once per frame
    void Update()
    {
        if (resetPositionAction.GetStateDown(SteamVR_Input_Sources.Any))
        {
            ResetRotation();
            ResetPosition();
        }
    }

    void ResetRotation()
    {
        // Assumes you want the headset forwad to be the local z-forward
        // Rotates playArea so that the headset points forward
        float globalDeltaEulerY = -(hmd.localRotation.eulerAngles.y + playArea.localRotation.eulerAngles.y);
        //Debug.Log($"hmd.rot: {hmd.localRotation.eulerAngles}, playArea.rot: {playArea.localRotation.eulerAngles}, globalDelta: {globalDeltaEulerY}");
        playArea.rotation *= Quaternion.Euler(0, globalDeltaEulerY, 0);
    }

    void ResetPosition()
    {
        // TODO: clean this up using calls to transform.position.Translate()
        Vector3 globalDelta = targetHeadsetTransform.position - hmd.position;
        //Debug.Log($"hmd.pos: {hmd.position}, target.position: {targetHeadsetTransform.position}, globalDelta: {globalDelta}, playArea.pos: {playArea.position}");
        playArea.position += globalDelta;
    }
}
