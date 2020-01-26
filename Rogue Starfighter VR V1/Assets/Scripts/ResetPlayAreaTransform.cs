using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ResetPlayAreaTransform : MonoBehaviour
{
    [SerializeField]
    Transform hmd = default;

    [SerializeField]
    Transform playArea = default;

    [SerializeField]
    Transform targetHeadsetTransform = default;

    [SerializeField]
    SteamVR_Action_Boolean resetPositionAction = default;

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
        // TODO: clean this up with quaternion math
        //Quaternion globalDelta = Quaternion.LookRotation(targetHeadsetPosition.position-hmd.position, targetHeadsetPosition.up);
        Vector3 globalDeltaEuler = -(hmd.rotation.eulerAngles - targetHeadsetTransform.rotation.eulerAngles);
        globalDeltaEuler.z = 0;
        globalDeltaEuler.x = 0;
        //Debug.Log($"hmd.rot: {hmd.rotation.eulerAngles}, target.rot: {targetHeadsetTransform.rotation.eulerAngles}, globalDelta: {globalDeltaEuler}");
        playArea.rotation *= Quaternion.Euler(globalDeltaEuler);
    }

    void ResetPosition()
    {
        // TODO: clean this up using calls to transform.position.Translate()
        Vector3 globalDelta = targetHeadsetTransform.position - hmd.position;
        //Debug.Log($"hmd.pos: {hmd.position}, target.position: {targetHeadsetTransform.position}, globalDelta: {globalDelta}, playArea.pos: {playArea.position}");
        playArea.position += globalDelta;
        //Debug.Log($"playArea.pos: {playArea.position}");
    }
}
