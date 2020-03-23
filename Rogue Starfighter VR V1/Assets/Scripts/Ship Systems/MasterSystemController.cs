using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MasterSystemController : MonoBehaviour
{
    [SerializeField] private List<ShipSystemAbstract> shipSystems = new List<ShipSystemAbstract>();
    [SerializeField] private ButtonGameController buttonGameController = default;
    [SerializeField] private TextWriteOn systemDisplayText = default;

    public UnityEvent OnSystemDisable;
    public UnityEvent OnSystemRepair;

    [ContextMenu("Disable random system")]
    public async void DisableRandomSystem()
    {
        ShipSystemAbstract chosenSystem = GetRandomShipSystem();
        chosenSystem.DisableSystem();
        string offlineText = $"{chosenSystem.GetShipSystemName} offline!\nPress the buttons to repair.";
        Debug.Log(offlineText);
        systemDisplayText.WriteOnText(offlineText);
        OnSystemDisable.Invoke();

        await buttonGameController.RequireRandomNumberOfButtonsPressed();

        chosenSystem.RepairSystem();
        systemDisplayText.WriteOffText();
        OnSystemRepair.Invoke();
    }

    //public async void DisableRandomSystem(int numberButtonsRequiredToPress)
    //{
    //    IShipSystem chosenSystem = GetRandomShipSystem();
    //    chosenSystem.DisableSystem();

    //    await buttonGameController.RequireButtonsPressed(numberButtonsRequiredToPress);

    //    chosenSystem.RepairSystem();
    //}

    private ShipSystemAbstract GetRandomShipSystem()
    {
        int index = Random.Range(0, shipSystems.Count);
        return shipSystems[index];
    }
}
