using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumericTextLabelControl : MonoBehaviour
{
    [SerializeField] private string prefix = default;

    //private TextMeshPro text;
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
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
