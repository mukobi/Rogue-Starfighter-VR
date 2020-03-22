using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMProOverlaySet : MonoBehaviour
{
    [SerializeField] private bool isOverlay = default;

    void Start()
    {
        var textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        if (textMeshProUGUI != null) textMeshProUGUI.isOverlay = isOverlay;
        var textMeshPro = GetComponent<TextMeshPro>();
        if (textMeshPro != null) textMeshPro.isOverlay = isOverlay;

        if (textMeshProUGUI == null && textMeshPro == null)
            Debug.LogWarning("Why no TextMeshPro component?", gameObject);
    }
}
