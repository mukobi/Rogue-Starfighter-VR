using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MasterSystemController : MonoBehaviour
{
    [SerializeField] private List<BreakableShipSystemAbstract> breakableShipSystems = new List<BreakableShipSystemAbstract>();
    [SerializeField] private ButtonGameController buttonGameController = default;
    [SerializeField] private TextWriteOn systemDisplayText = default;

    public UnityEvent OnSystemDisable;
    public UnityEvent OnSystemRepair;

    private bool aSystemIsDisabled = false;

    [ContextMenu("Disable random system")]
    public async void DisableRandomSystem()
    {
        if (aSystemIsDisabled)
            return; // only 1 system can be disabled at a time
        BreakableShipSystemAbstract chosenSystem = GetRandomShipSystem();
        chosenSystem.DisableSystem();
        aSystemIsDisabled = true;
        string offlineText = $"{chosenSystem.GetShipSystemName} offline!\nPress the buttons to repair.";
        Debug.Log(offlineText);
        systemDisplayText.WriteOnText(offlineText);
        OnSystemDisable.Invoke();

        await buttonGameController.RequireRandomNumberOfButtonsPressed();

        chosenSystem.RepairSystem();
        aSystemIsDisabled = false;
        systemDisplayText.WriteOffText();
        OnSystemRepair.Invoke();
    }


    public void RepairAllSystemsSilently()
    {
        // TODO handle fixing the button game since it will probably still be flashing.
        // This might require fancy async Task stuff.
        for (int i = 0; i < breakableShipSystems.Count; i++)
        {
            if (breakableShipSystems[i].shipSystemIsDisabled)
            {
                breakableShipSystems[i].RepairSystem();
            }
        }
    }

    private BreakableShipSystemAbstract GetRandomShipSystem()
    {
        int index = Random.Range(0, breakableShipSystems.Count);
        return breakableShipSystems[index];
    }
}
