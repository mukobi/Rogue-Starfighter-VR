using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimmableLight : DimmableAbstract
{
    private Light lightComponent;
    private float initialLightIntensity;

    private void Start()
    {
        lightComponent = GetComponent<Light>();
        initialLightIntensity = lightComponent.intensity;
    }

    public override float DimmableValue01 { set { lightComponent.intensity = value * initialLightIntensity; } }
}
