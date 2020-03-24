using UnityEngine.Events;
using UnityEngine;

public abstract class BaseEvent : MonoBehaviour
{
    public UnityEvent OnEvent;

#if UNITY_EDITOR
    [ContextMenu("Trigger Event")]
    public virtual void TriggerEvent()
    {
        OnEvent.Invoke();
    }
#endif
}
