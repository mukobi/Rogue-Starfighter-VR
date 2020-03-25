using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MasterSystemController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private List<BreakableShipSystemAbstract> breakableShipSystems = new List<BreakableShipSystemAbstract>();
    [SerializeField] private ButtonGameController buttonGameController = default;
    [SerializeField] private TextWriteOn systemDisplayText = default;

    [Header("Config")]
    [Tooltip("How long to wait for play to satisfy button request before automatically fixing all systems.")]
    [SerializeField] private float repairTimeoutDurationSeconds = 30;

    [Header("Events")]
    public UnityEvent OnSystemDisable;
    public UnityEvent OnSystemRepair;

    private bool aSystemIsDisabled = false;
    private CancellationTokenSource cts;

    [ContextMenu("Disable random system")]
    public async void DisableRandomSystem()
    {
        if (aSystemIsDisabled)
            return; // only 1 system can be disabled at a time

        cts = new CancellationTokenSource();
        CancellationToken ct = cts.Token;

        BreakableShipSystemAbstract chosenSystem = GetRandomShipSystem();
        chosenSystem.DisableSystem();
        aSystemIsDisabled = true;

        string offlineText = $"{chosenSystem.GetShipSystemName} offline!\nPress the buttons to repair.";
        Debug.Log(offlineText);
        systemDisplayText.WriteOnText(offlineText);

        OnSystemDisable.Invoke();

        // TODO: support not using a timeout as in a tutorial
        Task timeoutTask = Task.Delay((int)(repairTimeoutDurationSeconds * 1000));

        Task finishedTask = await Task.WhenAny(buttonGameController.RequireRandomNumberOfButtonsPressed(ct), timeoutTask);
        await finishedTask; // propogate exception if task finished because of exception

        if (finishedTask == timeoutTask)
        {
            Debug.Log($"System repair by {repairTimeoutDurationSeconds} second timeout. Get faster at pushing buttons.");
        }

        cts.Cancel();

        chosenSystem.RepairSystem();
        aSystemIsDisabled = false;
        systemDisplayText.WriteOffText();
        OnSystemRepair.Invoke();
    }

    [ContextMenu("Repair all systems silently (no events invoked)")]
    public void RepairAllSystemsSilently()
    {
        cts?.Cancel();

        for (int i = 0; i < breakableShipSystems.Count; i++)
        {
            if (breakableShipSystems[i].shipSystemIsDisabled)
            {
                breakableShipSystems[i].RepairSystem();
            }
        }
        aSystemIsDisabled = false;
    }

    private BreakableShipSystemAbstract GetRandomShipSystem()
    {
        int index = Random.Range(0, breakableShipSystems.Count);
        return breakableShipSystems[index];
    }
}
