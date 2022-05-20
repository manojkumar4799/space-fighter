using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingwave = 0;
    [SerializeField] bool looping=true;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
           yield return  StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }
    private IEnumerator SpawnAllWaves()
    {
        for(int WaveIndex=startingwave;WaveIndex<waveConfigs.Count;WaveIndex++)
        {
            var CurrentWave = waveConfigs[WaveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(CurrentWave));
        }
    }
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNoOfEnemies(); enemyCount++)
        {

           var newEnemy=
                Instantiate(waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            newEnemy.GetComponent<Greenenemypath>().SettingWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeSpawns());
        }
    }

}



