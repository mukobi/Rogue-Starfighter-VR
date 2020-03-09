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
        UnityEditor.EditorApplication.Beep();
        if (collision.gameObject.GetComponent<CollideableShipAbstract>() != null)
        {
            // collided with another ship
            Debug.Log($"Ship collision! {collision.contactCount} contacts");
            foreach (ContactPoint contact in collision.contacts)
            {
                Debug.DrawRay(contact.point, contact.normal * 10, Color.green, 1.0f);
            }
            //UnityEditor.EditorApplication.isPaused = true;
        }
    }
}
