using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollideableShipAbstract : MonoBehaviour
{
    protected readonly bool debugMode = false;

    private bool hasCollisionEnteredThisFrame;

    UnityEventVector3 onShipCollision;

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
            if (collision.gameObject.GetComponent<CollideableShipAbstract>() != null)
            {
                hasCollisionEnteredThisFrame = true;
                if(debugMode) Debug.Log($"{gameObject.name} collided with {collision.gameObject.name}");
                HandleShipCollision(collision);
            }
        }
    }

    protected virtual void HandleShipCollision(Collision collision)
    {
        // do nothing for now, see override in CollideableShipBounceOff.cs
    }
}
