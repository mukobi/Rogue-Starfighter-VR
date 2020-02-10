using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerISDSpawn : MonoBehaviour
{
    [SerializeField] private ISDSpawner iSDSpawner = default;
    [Tooltip("Will spawn ISD in at player's transform with a given position offset.")]
    [SerializeField] private Transform playerShip = default;
    [SerializeField] private Vector3 spawnPosOffset = default;

    public void SpawnISD()
    {
        Debug.Log("Spawning an ISD");
        Vector3 spawnPosWorld = playerShip.TransformPoint(spawnPosOffset);
        iSDSpawner.SpawnISD(spawnPosWorld, playerShip.position);
    } 

    public void RemoveAllISDs()
    {
        Debug.Log("Removing all ISDs");
        iSDSpawner.RemoveAllISDs();
    }
}
