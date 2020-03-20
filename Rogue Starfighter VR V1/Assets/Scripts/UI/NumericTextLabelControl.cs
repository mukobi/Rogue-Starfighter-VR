using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumericTextLabelControl : MonoBehaviour
{
    [SerializeField] private string prefix = default;
    [SerializeField] private string format = default;

    //private TextMeshPro text;
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void SetText(float value)
    {
        text.text = prefix + value.ToString(format);
    }

    public void SetText(int value)
    {
        text.text = prefix + value.ToString(format);
    }
}
