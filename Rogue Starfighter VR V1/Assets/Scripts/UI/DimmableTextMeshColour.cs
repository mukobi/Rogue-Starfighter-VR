using TMPro;
using UnityEngine;

public class DimmableTextMeshColour : DimmableAbstract
{
    private TextMeshProUGUI textMesh;
    private Color initialColor;
    [SerializeField] private Color fadeColor = default;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        initialColor = textMesh.color;
    }

    public override float DimmableValue01 { set => textMesh.color = Color.Lerp(fadeColor, initialColor, value); }
}
