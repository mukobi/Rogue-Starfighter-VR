using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Threading.Tasks;

public class StartTimer : MonoBehaviour
{
    public int TimerDurationMilliseconds;
    public UnityEvent OnTimerFinished;

    private async void Start()
    {
        await Task.Delay(TimerDurationMilliseconds);
        OnTimerFinished.Invoke();
        Destroy(this);
    }
}
