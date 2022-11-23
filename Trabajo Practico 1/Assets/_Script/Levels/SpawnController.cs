using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public ConfigLevelSpawn configLevelSpanws;
    public float timeBetweenSpawn;
    SpawnEnemy spawnEnemy;

    private void Awake()
    {
        EnemyPool.Current.InitConfig(configLevelSpanws);
        spawnEnemy = GetComponent<SpawnEnemy>();
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int type = 0; type < configLevelSpanws.configEnemy.Length; type++)
        {
            for (int amount = 0; amount < configLevelSpanws.configEnemy[type].amount; amount++)
            {
                string enemyName = configLevelSpanws.configEnemy[type].enemyName;
                spawnEnemy.Spawn(enemyName);
                yield return new WaitForSeconds(timeBetweenSpawn);
            }
        }
            
    }
}
