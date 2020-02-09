using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISDSpawner : MonoBehaviour
{
    [SerializeField] private GameObject imperialStarDestroyerPrefab;

    public void SpawnISD(Vector3 spawnLocation, Vector3 positionToPointTo)
    {
        GameObject ISD = Instantiate(imperialStarDestroyerPrefab, spawnLocation, Quaternion.identity, transform);  // parent to me
        ISD.transform.LookAt(positionToPointTo);
    }
}
