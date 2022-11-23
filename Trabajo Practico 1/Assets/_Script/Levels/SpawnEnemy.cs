using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnEnemy : MonoBehaviour
{
    public List<GameObject> spawnPointEnemys;

    private int spawnPointEnemyCount;

    private void Awake()
    {
        spawnPointEnemyCount = spawnPointEnemys.Count;
    }

    public void Spawn(string tag)
    {
        int randomSpawn = Random.Range(0, spawnPointEnemyCount);
        GameObject enemy = EnemyPool.Current.GetEnemyFromPool(tag);

        enemy.SetActive(true);
        enemy.transform.position = spawnPointEnemys[randomSpawn].transform.position;
    }
}
