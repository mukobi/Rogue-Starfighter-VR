using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ResetPlayAreaPosition : MonoBehaviour
{
    [SerializeField]
    Transform hmd = default;

    [SerializeField]
    Transform playArea = default;

    [SerializeField]
    Transform targetHeadsetPosition = default;

    [SerializeField]
    SteamVR_Action_Boolean resetPositionAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (resetPositionAction.GetStateDown(SteamVR_Input_Sources.Any))
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        Vector3 globalDelta = targetHeadsetPosition.position - hmd.position;
        playArea.Translate(globalDelta);
    }
}
