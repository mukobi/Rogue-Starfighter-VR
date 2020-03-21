using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTargetInRange: MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float range;

    private float sqrRange;

    private void Start()
    {
        sqrRange = range * range;
    }

    public bool TargetIsInRange { 
        get {
            return (target.position - transform.position).sqrMagnitude <= sqrRange;
        }
    }
}
