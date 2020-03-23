using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinPowerSystem : ShipSystemAbstract
{
    public DimmableAbstract[] dimmables;

    public override string GetShipSystemName => "Cabin Power";

    [SerializeField] private float currentFlickerValue = 1;

    private Animator animator;
    [SerializeField] private string animationName = default;
    [SerializeField] private int animationDurationFrames = default;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    [ContextMenu("Disable System")]
    public override void DisableSystem()
    {
        Debug.Log("Child");
        base.DisableSystem();
        StartCoroutine(PlayFlickerAnimationCoroutine(false));
    }

    [ContextMenu("Repair System")]
    public override void RepairSystem()
    {
        base.RepairSystem();
        StartCoroutine(PlayFlickerAnimationCoroutine(true));
    }

    private IEnumerator PlayFlickerAnimationCoroutine(bool reversed)
    {
        for (int i = 0; i <= animationDurationFrames; i++)
        {
            // play animation to chosen position
            float offset = (float)i / animationDurationFrames;
            if (reversed) offset = 1 - offset;
            animator.Play(animationName, 0, offset);

            // set the value on all the dimmable items
            for (int j = 0; j < dimmables.Length; j++)
            {
                // TODO: tween with a library instead for flicker effect
                dimmables[j].DimmableValue01 = currentFlickerValue;
            }

            yield return null;
        }
    }
}
