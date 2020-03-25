using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGameController : MonoBehaviour
{
    [SerializeField] private int buttonsToPressMin = default;
    [SerializeField] private int buttonsToPressMax = default;

    public List<ButtonSmall> buttons;

    [ContextMenu("Require Random Number Of Buttons Pressed")]
    public async Task RequireRandomNumberOfButtonsPressed(CancellationToken ct)
    {
        await RequireButtonsPressed(ct, Random.Range(buttonsToPressMin, buttonsToPressMax));
    }

    public async Task RequireButtonsPressed(CancellationToken ct, int numButtons)
    {
        List<ButtonSmall> randomButtons = ChooseRandomButtons(numButtons);
        var buttonTasks = randomButtons.Select(button => button.RequireButtonPress(ct));
        await Task.WhenAll(buttonTasks);
    }

    private List<ButtonSmall> ChooseRandomButtons(int numButtons)
    {
        List<ButtonSmall> chosen = new List<ButtonSmall>();
        for (int i = 0; i < numButtons; i++)
        {
            for (int j = 0; j < 16; j++) // try 16 times to not repick
            {
                ButtonSmall selected = buttons[Random.Range(0, buttons.Count)];
                if (!chosen.Contains(selected))
                {
                    // found a new button
                    chosen.Add(selected);
                    break;
                }
            }
        }
        return chosen;
    }
}
