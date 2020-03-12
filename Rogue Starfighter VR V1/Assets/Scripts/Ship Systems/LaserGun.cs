using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserGun : MonoBehaviour
{
    public MoveOppositePlayerMovement moveOppositePlayerMovement;
    public GameObject laserPrefab;

    public UnityEvent fireEvent;
    
    public void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, transform.rotation, moveOppositePlayerMovement.transform);
        fireEvent.Invoke();
    }
}
