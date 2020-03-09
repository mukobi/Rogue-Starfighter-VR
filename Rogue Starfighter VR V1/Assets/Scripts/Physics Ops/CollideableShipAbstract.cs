using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollideableShipAbstract : MonoBehaviour
{
    private bool hasCollisionEnteredThisFrame;

    private void LateUpdate()
    {
        // only allow accounting for 1 collision per frame
        // because descendants can change my transform, causing new collisions
        hasCollisionEnteredThisFrame = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasCollisionEnteredThisFrame)
        {
            hasCollisionEnteredThisFrame = true;
            Debug.Log($"{gameObject.name} collided with {collision.gameObject.name}");
            HandleCollision(collision);
        }
    }

    protected virtual void HandleCollision(Collision collision)
    {
        // do nothing for now, see override in CollideableShipBounceOff.cs
    }
}
