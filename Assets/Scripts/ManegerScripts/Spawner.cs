using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float waitToSpawn;
    public List<GameObject> spawnPoints;
    public List<GameObject> enemyList;
    public float cooldown;
    float cdr;

    void Start()
    {
        cdr = cooldown*waitToSpawn;
    }
    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

       void SpawnEnemy()
    {
        if (cdr > 0)
        {
            cdr -= Time.deltaTime;
        }
        else
        {
            cdr = cooldown;
            int chosenSpawnPoint = Random.Range(0,spawnPoints.Count);
            int index = Random.Range(0, enemyList.Count);
            Instantiate(enemyList[index],spawnPoints[chosenSpawnPoint].transform.position, Quaternion.identity);
        }
     
    }
    public void ResetCd()
    {
        cdr = cooldown;
    }

}
