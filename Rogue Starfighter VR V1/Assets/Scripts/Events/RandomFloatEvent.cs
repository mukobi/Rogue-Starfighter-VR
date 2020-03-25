using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFloatEvent : MonoBehaviour
{
    [SerializeField] private float min = default;
    [SerializeField] private float max = default;

    public UnityEventFloat FloatEvent;

    [ContextMenu("Do it!")]
    public void InvokeEventWithRandomizedFloat()
    {
        FloatEvent.Invoke(Random.Range(min, max));
    }
}
