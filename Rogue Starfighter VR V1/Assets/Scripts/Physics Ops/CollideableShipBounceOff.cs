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
                Debug.DrawRay(contact.point, contact.normal * 5, Color.blue, 0.66f);
            }

            // assume first contact best (not sure if this works? ¯\_(ツ)_/¯)
            ContactPoint contactPoint = collision.GetContact(0);
            Vector3 actualCollidedSurfaceNormal = CalculateCollisionNormal(contactPoint);
            Debug.DrawRay(contactPoint.point, actualCollidedSurfaceNormal * 16, Color.green, 0.66f);
            BounceMyselfOffCollision(actualCollidedSurfaceNormal);
            //UnityEditor.EditorApplication.isPaused = true;
        }
    }

    private Vector3 CalculateCollisionNormal(ContactPoint contactPoint)
    {
        const float rayStepBackLength = 5.0f;
        const float rayLength = 16.0f;


        Vector3 point = contactPoint.point;
        Vector3 contactNormal = contactPoint.normal;

        // step back a bit
        point += rayStepBackLength * contactNormal;

        // cast a ray several times as far as your step back. This seems to work in most
        // situations, at least when speeds are not ridiculously big
        RaycastHit hitInfo;
        Ray ray = new Ray(point, -contactNormal);
        if (contactPoint.otherCollider.Raycast(ray, out hitInfo, rayLength))
        {
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.yellow, 0.66f);
            // this is the actual collider surface normal
            return hitInfo.normal;
        }

        // simple raycast in direction of contactNormal failed (maybe high incident angle, so 
        // instead we need to raycast from the direction of this ship towards the collision point
        Debug.LogWarning("No raycast hit from collision normal, trying raycast from ship");
        Vector3 rayOrigin = transform.position - rayStepBackLength * transform.forward;
        Vector3 rayDirection = (contactPoint.point - transform.position).normalized;
        ray = new Ray(rayOrigin, rayDirection);
        if (contactPoint.otherCollider.Raycast(ray, out hitInfo, rayLength))
        {
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.magenta, 0.66f);
            // this is the actual collider surface normal
            return hitInfo.normal;
        }

        // nothing worked!
        Debug.LogError("No Raycast hit for calculating ship collision normal.");
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red, 0.66f);
        UnityEditor.EditorApplication.isPaused = true;
        return contactNormal;
    }

    private void BounceMyselfOffCollision(Vector3 normal)
    {
        // calculate reflection of vector across normal: r = d - 2(dot(d,n))n
        Vector3 newForward = transform.forward - 2 * Vector3.Dot(transform.forward, normal) * normal;
        Debug.Log(newForward);

        // use same up vector as before to preserve rotation about forward axis
        Vector3 oldUp = transform.up;

        // set my new reflected rotation
        transform.rotation = Quaternion.LookRotation(newForward, oldUp);

        // to avoid multiple collisions, jump ahead in reflected and normal directions a little
        transformToJumpAheadOnCollision.position += collisionJumpBias * newForward.normalized;
        transformToJumpAheadOnCollision.position += collisionJumpBias * normal;
    }
}
