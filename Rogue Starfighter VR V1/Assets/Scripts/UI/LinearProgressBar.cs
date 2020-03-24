using UnityEngine.Events;
using UnityEngine;

public class LinearProgressBar : MonoBehaviour
{
    [SerializeField] private float MinValue = 0;
    [SerializeField] private float MaxValue = 100;
    //[SerializeField] private float defaultValue = 100;

    [SerializeField] private RectTransform fill = default;

    public UnityEventFloat OnValueSet;

    //private void Start()
    //{
    //    SetValue(defaultValue);
    //}

    public void SetValue(float value)
    {
        value = Mathf.Clamp(value, MinValue, MaxValue);
        float x = (value - MinValue) / (MaxValue - MinValue);
        fill.localScale = new Vector3(x, 1, 1);
        OnValueSet.Invoke(value);
    }
}
