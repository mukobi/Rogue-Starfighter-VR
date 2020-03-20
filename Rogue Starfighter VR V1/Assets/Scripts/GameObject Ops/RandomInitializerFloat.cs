using UnityEngine;
using UnityEngine.Events;

public class RandomInitializerFloat : MonoBehaviour
{
    [SerializeField] private float min = default;
    [SerializeField] private float max = default;

    [SerializeField] private UnityEventFloat randomValueOnStart;

    private void Start()
    {
        randomValueOnStart.Invoke(Random.Range(min, max));
    }
}
