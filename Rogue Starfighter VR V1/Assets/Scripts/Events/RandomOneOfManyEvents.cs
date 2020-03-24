using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOneOfManyEvents : MonoBehaviour
{
    [SerializeField] private BaseEvent[] events = default;

    public void InvokeSingleRandomEvent()
    {
        events[Random.Range(0, events.Length)].OnEvent.Invoke();
    }
}
