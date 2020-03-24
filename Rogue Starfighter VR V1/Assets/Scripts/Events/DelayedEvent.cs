using UnityEngine.Events;
using UnityEngine;
using System.Collections;

public class DelayedEvent : MonoBehaviour
{
    [SerializeField] private float delaySeconds = default;

    [SerializeField] UnityEvent OnEvent = default;

    public void TriggerEventAfterDelay()
    {
        StartCoroutine(DelayedEventCoroutine());
    }

    private IEnumerator DelayedEventCoroutine()
    {
        yield return new WaitForSeconds(delaySeconds);
        OnEvent.Invoke();
    }
}
