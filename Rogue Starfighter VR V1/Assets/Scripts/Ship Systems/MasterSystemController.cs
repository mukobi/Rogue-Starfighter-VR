using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class MasterSystemController : MonoBehaviour
{
    [SerializeField] private List<ShipSystemAbstract> shipSystems = new List<ShipSystemAbstract>();
    [SerializeField] private ButtonGameController buttonGameController = default;

    public async void DisableRandomSystem()
    {
        ShipSystemAbstract chosenSystem = GetRandomShipSystem();
        chosenSystem.DisableSystem();

        await buttonGameController.RequireRandomNumberOfButtonsPressed();

        chosenSystem.RepairSystem();
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
