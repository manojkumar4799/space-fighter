using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greenenemypath : MonoBehaviour
{
     WaveConfig waveConfig;
     List<Transform> wayPoints;
    int waypointindex = 0;
    // Start is called before the first frame update
    void Start()
    {
        wayPoints = waveConfig.GetWaypoints();
        transform.position = wayPoints[waypointindex].transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    public void SettingWaveConfig(WaveConfig waveconfig)
    {
        this.waveConfig = waveconfig;
    }
    private void EnemyMove()
    {
        if (waypointindex <= wayPoints.Count - 1)
        {
            var TargetPosition = wayPoints[waypointindex].transform.position;
            var MovementSpeed = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, TargetPosition, MovementSpeed);

            if (transform.position == TargetPosition)
            {
                waypointindex++;
            } 
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
