using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControlStick : MonoBehaviour
{
    public SteamVR_Action_Boolean GrabJoystick;

    // Start is called before the first frame update
    void Start()
    {
        GrabJoystick.onStateDown += GrabJoystickDown;
        GrabJoystick.onStateUp += GrabJoystickUp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GrabJoystickDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Grab stick down from source " + fromSource);
    }
    private void GrabJoystickUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Grab stick up from source " + fromSource);
    }
}
