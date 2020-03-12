using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float DestroyTimeSeconds = default;

    private void Awake()
    {
        Destroy(gameObject, DestroyTimeSeconds);
    }
}
