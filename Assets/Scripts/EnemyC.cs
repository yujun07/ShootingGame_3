using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyC : Enemy
{
    public float curShotDelay;
    public float maxShotDelay;
    
    void Fire()
    {
        if (GameManager.instance.isGameover == false)
        {
            GameObject emObject = GameObject.Find("EnemyManager");
            EnemyManager manager = emObject.GetComponent<EnemyManager>();
            if (curShotDelay < maxShotDelay)
                return;
            if (manager.enemyBulletObjectPool.Count > 0)
            {
                GameObject enemyBullet = manager.enemyBulletObjectPool[0];
                enemyBullet.SetActive(true);

                manager.enemyBulletObjectPool.Remove(enemyBullet);

                enemyBullet.transform.position = transform.position;
            }
            curShotDelay = 0;
        }
    }
    void Reload()
    {
        if (GameManager.instance.isGameover == false)
        {
            curShotDelay += Time.deltaTime;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject emObject = GameObject.Find("EnemyManager");
        EnemyManager manager = emObject.GetComponent<EnemyManager>();
        manager.enemyBulletObjectPool = new List<GameObject>();
        for (int i = 0; i < manager.bulletPoolSize; i++)
        {

            GameObject enemyBullet = Instantiate(manager.enemyBulletFactory);
            manager.enemyBulletObjectPool.Add(enemyBullet);
            
            enemyBullet.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        Reload();
    }
}
