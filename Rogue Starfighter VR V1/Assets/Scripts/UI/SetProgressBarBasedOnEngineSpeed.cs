using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetProgressBarBasedOnEngineSpeed : MonoBehaviour
{
    [SerializeField] private LinearProgressBar linearProgressBar;
    [SerializeField] private ForwardEngine engine;

    private void Update()
    {
        linearProgressBar.SetValue(engine.CurrentSpeed);
    }
}
