using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOneOfManyEvents : ActionableAbstract
{
    [SerializeField] private BaseEvent[] events = default;

    [ContextMenu("Trigger Random Event")]
    public override void DoAction()
    {
        events[Random.Range(0, events.Length)].OnEvent.Invoke();
    }
}
