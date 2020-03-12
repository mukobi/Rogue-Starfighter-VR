using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float DestroyTimeSeconds;

    private void Awake()
    {
        Destroy(gameObject, DestroyTimeSeconds);
    }
}
