using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerISDSpawn : MonoBehaviour
{
    [SerializeField] private ISDSpawner iSDSpawner;
    [Tooltip("Will spawn ISD in at player's transform with a given position offset.")]
    [SerializeField] private Transform playerShip;
    [SerializeField] private Vector3 spawnPosOffset;
    [SerializeField] private Vector3 spawnRotOffsetEuler;

    public void SpawnISD()
    {
        Debug.Log("Spawning an ISD");
        iSDSpawner.SpawnISD(playerShip.position + spawnPosOffset, Quaternion.Euler(spawnPosOffset) * playerShip.localRotation);
    } 
}
