using System.Collections;
using UnityEngine.Events;
using UnityEngine;

public enum SFoilState
{
    closed,
    transitioning,
    attack
}

public class SFoilAnimator : MonoBehaviour
{
    [SerializeField] private Transform wingTopLeft = default;
    [SerializeField] private Transform wingTopRight = default;

    [SerializeField] private float openWingRotationDegrees = default;
    [SerializeField] private float wingAnimationTimeSeconds = default;
    [SerializeField] private float animationStartDelaySeconds = default;

    private float currentWingZRotation = 0;
    private Vector3 currentWingRotationEuler = Vector3.zero;

    public SFoilState CurrentSFoilState { get; private set; } = SFoilState.closed;

    public UnityEvent OnSFoilAttackTransitionStart;
    public UnityEvent OnSFoilAttackTransitionEnd;
    public UnityEvent OnSFoilClosedTransitionStart;
    public UnityEvent OnSFoilClosedTransitionEnd;

    [ContextMenu("Toggle S-Foil Position")]
    public void ToggleSFoilPosition()
    {
        if (CurrentSFoilState == SFoilState.closed)
        {
            LockInAttackPosition();
        }
        else if (CurrentSFoilState == SFoilState.attack)
        {
            LockInClosedPosition();
        }
    }

    [ContextMenu("Lock In Attack Position")]
    public void LockInAttackPosition()
    {
        StartCoroutine(LockInAttackPositionCoroutine());
    }

    [ContextMenu("Lock In Closed Position")]
    public void LockInClosedPosition()
    {
        StartCoroutine(LockInClosedPositionCoroutine());
    }

    private IEnumerator LockInAttackPositionCoroutine()
    {
        if (CurrentSFoilState != SFoilState.closed)
        {
            Debug.LogError($"Trying to set s-foil with state {CurrentSFoilState} to attack position.");
            yield break;
        }
        if (currentWingZRotation != 0)
        {
            Debug.LogError($"Trying to set s-foil with rotation {currentWingZRotation} to attack position.");
            yield break;
        }

        CurrentSFoilState = SFoilState.transitioning;
        OnSFoilAttackTransitionStart.Invoke();
        yield return null;
        yield return new WaitForSeconds(animationStartDelaySeconds);

        float t;
        float startTime = Time.time;
        while ((t = (Time.time - startTime) / wingAnimationTimeSeconds) < 1.0f)
        {
            ApplyWingRotation(t);

            yield return null;
        }

        ApplyWingRotation(1);
        CurrentSFoilState = SFoilState.attack;
        OnSFoilAttackTransitionEnd.Invoke();
    }

    private IEnumerator LockInClosedPositionCoroutine()
    {
        if (CurrentSFoilState != SFoilState.attack)
        {
            Debug.LogError($"Trying to set s-foil with state {CurrentSFoilState} to closed position.");
            yield break;
        }
        if (currentWingZRotation != openWingRotationDegrees)
        {
            Debug.LogError($"Trying to set s-foil with rotation {currentWingZRotation} to closed position.");
            yield break;
        }

        CurrentSFoilState = SFoilState.transitioning;
        OnSFoilClosedTransitionStart.Invoke();
        yield return null;
        yield return new WaitForSeconds(animationStartDelaySeconds);

        float t;
        float startTime = Time.time;
        while ((t = (Time.time - startTime) / wingAnimationTimeSeconds) < 1.0f)
        {
            ApplyWingRotation(1.0f-t);

            yield return null;
        }

        ApplyWingRotation(0);
        CurrentSFoilState = SFoilState.closed;
        OnSFoilClosedTransitionEnd.Invoke();
    }

    private void ApplyWingRotation(float t)
    {
        // calculate rotation
        currentWingZRotation = Mathf.Lerp(0, openWingRotationDegrees, t);
        currentWingRotationEuler.z = currentWingZRotation;

        // apply rotation
        wingTopLeft.localEulerAngles = -currentWingRotationEuler;
        wingTopRight.localEulerAngles = currentWingRotationEuler;
    }
}
