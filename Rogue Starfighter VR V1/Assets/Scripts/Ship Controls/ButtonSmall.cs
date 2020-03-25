using System.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class ButtonSmall : MonoBehaviour
{
    public bool ButtonIsPressedMarker { get; set; }

    [SerializeField] private int buttonCheckIntervalMilliseconds = 100;

    public UnityEvent OnRequireButtonPress;
    public UnityEvent OnSatisfyButtonPress;

    [ContextMenu("Require button pressed")]
    public async Task RequireButtonPress(CancellationToken ct)
    {
        MarkButtonRequired();
        while (!ButtonIsPressedMarker
            && !ct.IsCancellationRequested)
        {
            await Task.Delay(buttonCheckIntervalMilliseconds);
        }
        MarkButtonSatisfied();
    }

    private void MarkButtonRequired()
    {
        ButtonIsPressedMarker = false;
        OnRequireButtonPress.Invoke();
    }

    private void MarkButtonSatisfied()
    {
        ButtonIsPressedMarker = false;
        OnSatisfyButtonPress.Invoke();
    }
}
