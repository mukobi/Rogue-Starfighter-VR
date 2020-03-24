using UnityEngine.Events;
using UnityEngine;
using System.Collections;

public class RandomIntervalLoopEvent : MonoBehaviour
{
    [SerializeField] private float minIntervalSeconds = 1;
    [SerializeField] private float maxIntervalSeconds = 1;
    [SerializeField] private UnityEvent OnEvent;

    private void Start()
    {
        StartCoroutine(RandomIntervalLoopCoroutine());
    }

    private IEnumerator RandomIntervalLoopCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minIntervalSeconds, maxIntervalSeconds));
            OnEvent.Invoke();
        }
    }
}
