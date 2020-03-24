using UnityEngine.Events;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class OnVisibilityEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent OnVisible = default;
    [SerializeField] private UnityEvent OnInvisible = default;

    private void OnBecameVisible()
    {
        OnVisible.Invoke();
    }

    private void OnBecameInvisible()
    {
        OnInvisible.Invoke();
    }
}
