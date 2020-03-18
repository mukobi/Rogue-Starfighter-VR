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

    private async void Start()
    {
        while (true)
        {
            await RequireRandomNumberOfButtonsPressed();
        }
    }

    public async Task RequireRandomNumberOfButtonsPressed()
    {
        await RequireButtonsPressed(Random.Range(buttonsToPressMin, buttonsToPressMax));
    }

    public async Task RequireButtonsPressed(int numButtons)
    {
        List<ButtonSmall> randomButtons = chooseRandomButtons(numButtons);
        var buttonTasks = randomButtons.Select(button => button.RequireButtonPress());
        await Task.WhenAll(buttonTasks);
    }

    private List<ButtonSmall> chooseRandomButtons(int numButtons)
    {
        List<ButtonSmall> chosen = new List<ButtonSmall>();
        for (int i = 0; i < numButtons; i++)
        {
            for (int j = 0; j < 16; j++) // try 5 times to not repick
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
