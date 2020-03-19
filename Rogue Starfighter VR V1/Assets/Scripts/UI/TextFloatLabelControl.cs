using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextFloatLabelControl : MonoBehaviour
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
}
