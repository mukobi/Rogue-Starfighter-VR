using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollideableShipAbstract : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{gameObject.name} collided with {collision.gameObject.name}");
        HandleCollision(collision);
    }

    protected virtual void HandleCollision(Collision collision)
    {
        // do nothing for now, see override in CollideableShipBounceOff.cs
    }
}
