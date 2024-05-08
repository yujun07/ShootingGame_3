using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float currentTime;

    public float minTime = 0.5f;

    public float maxTime = 1.5f;

    public float createTime = 1;

    public GameObject[] enemyFactorys;
    public GameObject enemyBulletFactory;
    public int poolSize = 20;
    public int bulletPoolSize = 100;

    public List<GameObject> enemyBulletObjectPool;
    public List<GameObject> enemyObjectPool;

    public Transform[] spawnPoints;
    
    void Start()
    {
        
        createTime = UnityEngine.Random.Range(minTime, maxTime);    

        enemyObjectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            int ranEnemy = UnityEngine.Random.Range(0, enemyFactorys.Length);
            int ranPoint = UnityEngine.Random.Range(0, spawnPoints.Length);
            GameObject enemy = Instantiate(enemyFactorys[ranEnemy], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);
            enemyObjectPool.Add(enemy);

            enemy.SetActive(false);
        }
    }
    void SpawnEnemy()
    {
        if (GameManager.instance.isGameover == false)
        {
            if (enemyObjectPool.Count > 0)
            {
                GameObject enemy = enemyObjectPool[0];

                enemyObjectPool.Remove(enemy);

                int index = Random.Range(0, spawnPoints.Length);

                enemy.transform.position = spawnPoints[index].position;

                enemy.SetActive(true);
            }
        }
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            SpawnEnemy();
            createTime = UnityEngine.Random.Range(minTime, maxTime);
            currentTime = 0;
        }
    }
}
