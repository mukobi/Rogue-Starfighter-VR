using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextColorLerpBasedOnTargetInRange : MonoBehaviour
{
    [SerializeField] private DetectTargetInRange detectTargetInRange = default;

    private LerpTextBetweenColors lerpTextBetweenColors;

    private void Start()
    {
        lerpTextBetweenColors = GetComponent<LerpTextBetweenColors>();
    }
    
    void Update()
    {
        lerpTextBetweenColors.isOn = !detectTargetInRange.TargetIsInRange;
    }
}
