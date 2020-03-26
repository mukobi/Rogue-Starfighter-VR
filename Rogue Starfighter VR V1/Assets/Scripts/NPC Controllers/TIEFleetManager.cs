using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIEFleetManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private RandomOneOfManyEvents spawner = default;
    [SerializeField] private BoidFlock boidFlock = default;


    [Header("Config")]
    public int MaxAliveTIEs = 48;
    [SerializeField] private float spawnIntervalSeconds = 1;

    public bool CanSpawnTIEs { get; set; } = true;

    private IEnumerator spawnCoroutine;

    private void OnEnable()
    {
        if (spawnCoroutine != null) StopCoroutine(spawnCoroutine);
        spawnCoroutine = SpawnLoopCoroutine();
        StartCoroutine(spawnCoroutine);
    }

    private IEnumerator SpawnLoopCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnIntervalSeconds);
            if(boidFlock.agents.Count < MaxAliveTIEs && CanSpawnTIEs)
            {
                spawner.DoAction();
            }
        }
    }
}
