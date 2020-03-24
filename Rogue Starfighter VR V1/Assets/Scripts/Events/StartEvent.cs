using UnityEngine.Events;
using UnityEngine;

public class StartEvent : MonoBehaviour
{
    public UnityEvent OnStart;

    private void Start()
    {
        OnStart.Invoke();
    }
}
