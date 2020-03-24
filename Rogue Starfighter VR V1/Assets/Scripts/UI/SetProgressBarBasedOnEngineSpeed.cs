using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetProgressBarBasedOnEngineSpeed : MonoBehaviour
{
    [SerializeField] private LinearProgressBar linearProgressBar = default;
    [SerializeField] private ForwardEngine engine = default;

    private void Update()
    {
        linearProgressBar.SetValue(engine.CurrentSpeed);
    }
}
