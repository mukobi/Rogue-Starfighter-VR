using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumericTextLabelControl : MonoBehaviour
{
    [SerializeField] private string prefix = default;

    private TextMeshPro text;

    private void Start()
    {
        text = GetComponent<TextMeshPro>();
    }

    public void SetText(float value)
    {
        text.text = prefix + value.ToString();
    }

    public void SetText(int value)
    {
        text.text = prefix + value.ToString();
    }
}
