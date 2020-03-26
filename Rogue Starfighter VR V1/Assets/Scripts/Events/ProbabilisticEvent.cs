using UnityEngine.Events;
using UnityEngine;

public class ProbabilisticEvent : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float probability = default;

    public UnityEvent OnLuckyRoll;

    [ContextMenu("Attempt Probabilistic Event")]
    public void AttemptProbabilisticEvent()
    {
        if (Random.value <= probability)
        {
            OnLuckyRoll.Invoke();
        }
    }
}
