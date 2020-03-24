using UnityEngine.Events;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class OnVisibilityEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent OnVisible = default;
    [SerializeField] private UnityEvent OnInvisible = default;

    private void OnBecameVisible()
    {
        Debug.Log("Visible");
        OnVisible.Invoke();
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Invisible");
        OnInvisible.Invoke();
    }
}
