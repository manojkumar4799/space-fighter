using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy Wave Config")] 
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns=0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] int numberOfEnemies =5;


    public GameObject GetEnemyPrefab()
    { 
        return enemyPrefab;
    }
    public List<Transform>  GetWaypoints()
    {
        var waypointsPath = new List<Transform>();
        foreach(Transform childs in pathPrefab.transform)
        {
            waypointsPath.Add(childs);
        }
        return waypointsPath;
    }
    public float GetTimeSpawns()
    {
        return timeBetweenSpawns;
    }
    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public int GetNoOfEnemies()
    {
        return numberOfEnemies;
    }
}
