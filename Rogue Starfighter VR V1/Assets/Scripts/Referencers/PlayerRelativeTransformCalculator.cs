using UnityEngine;

public class PlayerRelativeTransformCalculator : MonoBehaviour
{
    public Vector3 ToPlayer { get; private set; }
    public Vector3 ToPlayerNormalized { get; private set; }
    public float ToPlayerSqrMagnitude { get; private set; }
    public float AngleToPlayer { get; private set; }

    private void FixedUpdate()
    {
        ToPlayer = PlayerGlobalReference.I.AheadOfPlayerTarget.position - transform.position;
        ToPlayerNormalized = ToPlayer.normalized;
        ToPlayerSqrMagnitude = ToPlayer.sqrMagnitude;
        AngleToPlayer = Vector3.Angle(transform.forward, ToPlayerNormalized);
    }
}
