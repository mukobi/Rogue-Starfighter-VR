using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerateShipHealth : MonoBehaviour
{
    [SerializeField] private DamageableShipPartWithHealth shipWithHealth = default;

    [SerializeField] private float regenSpeed = default;
    [SerializeField] private float timeBeforeStartRegenSeconds = default;

    private IEnumerator waitingCoroutine;
    private IEnumerator regenCoroutine;

    public void ResetWaiting()
    {
        StopCoroutine(regenCoroutine);
        StopCoroutine(waitingCoroutine);

        waitingCoroutine = StartWaitingCoroutine();
        StartCoroutine(waitingCoroutine);
    }

    private IEnumerator StartWaitingCoroutine()
    {
        yield return new WaitForSeconds(timeBeforeStartRegenSeconds);
        regenCoroutine = StartRegenCoroutine();
        StartCoroutine(regenCoroutine);
    }

    private IEnumerator StartRegenCoroutine()
    {
        while(shipWithHealth.CurrentHealth < shipWithHealth.MaxHealth)
        {
            shipWithHealth.GainHealth(regenSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
