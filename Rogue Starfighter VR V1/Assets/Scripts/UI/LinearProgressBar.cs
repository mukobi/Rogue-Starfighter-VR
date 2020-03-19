using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearProgressBar : MonoBehaviour
{
    public float MinValue = 0;
    public float MaxValue = 100;
    [SerializeField] private float defaultValue = 100;

    [SerializeField] private RectTransform fill;

    private void Start()
    {
        SetValue(defaultValue);
    }

    public void SetValue(float value)
    {
        float x = (value - MinValue) / (MaxValue - MinValue);
        fill.localScale = new Vector3(x, 1, 1);
    }
}
