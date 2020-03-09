using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideableShipBounceOff : CollideableShipAbstract
{
    [Tooltip("Jump an object in reflected direction on impact to avoid multiple collisions.")]
    [SerializeField] private Transform transformToJumpAheadOnCollision = default;
    [Tooltip("How far to jump in reflected direction on impact.")]
    [SerializeField] private float collisionJumpBias = default;

    protected override void HandleCollision(Collision collision)
    {
        if (collision.gameObject.GetComponent<CollideableShipAbstract>() != null)
        {
            // collided with another ship
            Debug.Log($"Ship collision! {collision.contactCount} contacts");
            UnityEditor.EditorApplication.Beep();
            foreach (ContactPoint contact in collision.contacts)
            {
                Debug.DrawRay(contact.point, contact.normal * 10, Color.green, 0.66f);
            }
            //UnityEditor.EditorApplication.isPaused = true;

            // assume first contact best (not sure if this works? ¯\_(ツ)_/¯)
            ContactPoint contactPoint = collision.GetContact(0);
            BounceMyselfOffCollision(contactPoint.normal);
        }
    }

    private void BounceMyselfOffCollision(Vector3 normal)
    {
        // calculate reflection of vector across normal: r = d - 2(dot(d,n))n
        Vector3 newForward = transform.forward - 2 * Vector3.Dot(transform.forward, normal) * normal;

        // use same up vector as before to preserve rotation about forward axis
        Vector3 oldUp = transform.up;

        // set my new reflected rotation
        transform.rotation = Quaternion.LookRotation(newForward, oldUp);

        // to avoid multiple collisions, jump ahead in reflected direction a little
        transformToJumpAheadOnCollision.position += collisionJumpBias * newForward.normalized;
    }
}
