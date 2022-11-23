using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    private static EnemyPool _current;

    public static EnemyPool Current

    #region Singleton

    {
        get
        {
            if (_current == null)
            {
                _current = GameObject.FindObjectOfType<EnemyPool>();
            }

            return _current;
        }
    }

    #endregion Singleton

    private ConfigLevelEnemy[] configEnemys;
    private Dictionary<string, Queue<GameObject>> dictionaryEnemysToPool;

    

    public void InitConfig(ConfigLevelSpawn configLevelSpawn)
    {
        configEnemys = configLevelSpawn.configEnemy;
        dictionaryEnemysToPool = new Dictionary<string, Queue<GameObject>>();

        foreach (ConfigLevelEnemy typeEnemys in configEnemys)
        {
            Queue<GameObject> queueEnemySameType = new Queue<GameObject>();

            int roundCountEnemys = Mathf.RoundToInt(typeEnemys.amount / 2f);

            for (int i = 0; i < roundCountEnemys; i++)
            {
                GameObject enemy = Instantiate(typeEnemys.prefab, this.transform);
                enemy.gameObject.SetActive(false);
                queueEnemySameType.Enqueue(enemy);
            }

            dictionaryEnemysToPool.Add(typeEnemys.enemyName, queueEnemySameType);
        }
    }

    public GameObject GetEnemyFromPool(string typeEnemy)
    {
        Queue<GameObject> enemys = dictionaryEnemysToPool[typeEnemy];
        
        if (enemys.Count != 0)
        {
            return enemys.Dequeue();
        }

        foreach (ConfigLevelEnemy selectTypeEnemy in configEnemys)
        {
            if (selectTypeEnemy.enemyName == typeEnemy)
            {
                GameObject enemy = Instantiate(selectTypeEnemy.prefab, this.transform);
                enemy.gameObject.SetActive(false);
                return enemy;
            }
        }

        return null;
    }

    public void SetEnemyToPool(GameObject enemyToSetInPool, string tagEnemy)
    {
        enemyToSetInPool.SetActive(false);
        dictionaryEnemysToPool[tagEnemy].Enqueue(enemyToSetInPool);
    }

    //private void Awake()
    //{
    //    dictionaryEnemysToPool = new Dictionary<string, Queue<GameObject>>();

    //    foreach (EnemyToPool typeEnemys in listTypeEnemysToPool)
    //    {
    //        Queue<GameObject> queueEnemySameType = new Queue<GameObject>();

    //        int roundCountEnemys = Mathf.RoundToInt(typeEnemys.sizePool / 2f);

    //        for (int i = 0; i < roundCountEnemys; i++)
    //        {
    //            GameObject enemy = Instantiate(typeEnemys.prefabObject, this.transform);
    //            enemy.gameObject.SetActive(false);
    //            queueEnemySameType.Enqueue(enemy);
    //        }

    //        dictionaryEnemysToPool.Add(typeEnemys.tagEnemy, queueEnemySameType);
    //    }
    //}
}
