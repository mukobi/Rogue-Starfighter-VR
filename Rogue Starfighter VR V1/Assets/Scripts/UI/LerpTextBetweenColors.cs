using TMPro;
using UnityEngine;

public class LerpTextBetweenColors : MonoBehaviour
{
    public bool isOn;

    [SerializeField] private Color offColor = default;
    [SerializeField] private Color onColor = default;

    [SerializeField] private float lerpFactor = 1;

    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        Color targetColor = isOn ? onColor : offColor;
        if (text.color != targetColor)
        {
            text.color = Color.Lerp(text.color, targetColor, lerpFactor);
        }
    }
}
