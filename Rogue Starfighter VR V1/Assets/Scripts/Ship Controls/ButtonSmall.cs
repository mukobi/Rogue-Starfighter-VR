using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class ButtonSmall : MonoBehaviour
{
    public bool ButtonIsPressedMarker { get; set; }

    [SerializeField] private int buttonCheckIntervalMilliseconds = 100;

    public UnityEvent OnRequireButtonPress;
    public UnityEvent OnSatisfyButtonPress;

    public async Task RequireButtonPress()
    {
        ButtonIsPressedMarker = false;
        OnRequireButtonPress.Invoke();
        while (!ButtonIsPressedMarker)
        {
            await Task.Delay(buttonCheckIntervalMilliseconds);
        }
        ButtonIsPressedMarker = false;
        OnSatisfyButtonPress.Invoke();
    }
}
