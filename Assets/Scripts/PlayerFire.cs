using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject bulletLFactory;
    public GameObject bulletRFactory;
    

    public int poolSize = 200;
    public int power = 1;

    public float curShotDelay;
    public float maxShotDelay;

    public int maxPower = 5;
    public List<GameObject> bulletObjectPool;
    public List<GameObject> bulletLObjectPool;
    public List<GameObject> bulletRObjectPool;

    public Transform BulletPool;

    void OnTriggerEnter(Collider other)
    {
        GameObject emObject = GameObject.Find("EnemyManager");
        EnemyManager manager = emObject.GetComponent<EnemyManager>();
        GameObject itmObject = GameObject.Find("ItemManager");
        ItemManager itmManager = itmObject.GetComponent<ItemManager>();

        if (other.gameObject.tag == "Enemy")
        {
            
            other.gameObject.SetActive(false);

            manager.enemyObjectPool.Add(other.gameObject);
            GameManager.instance.Score++;
            Destroy(gameObject);
            GameManager.instance.isGameover = true;

        }
        if (other.gameObject.tag == "EnemyBullet")
        {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();

            Destroy(gameObject);
            GameManager.instance.isGameover = true;

            switch (bullet.Type)
            {
                case "E":
                    manager.enemyBulletObjectPool.Add(other.gameObject);
                    other.gameObject.SetActive(false);
                    break;
            }
        }

        if (other.gameObject.tag == "Item")
        {
            Item item = other.gameObject.GetComponent<Item>();
            switch (item.type)
            {
                case "P":
                    if (power == maxPower)
                    {
                        GameManager.instance.Score += 5;
                    }
                    else
                    {
                        power++;
                    }
                    break;
            }
            other.gameObject.SetActive(false);
            itmManager.itemObjectPool.Add(other.gameObject);
        }
        
    }

    void Start()
    {
        bulletObjectPool = new List<GameObject>();
        bulletLObjectPool = new List<GameObject>();
        bulletRObjectPool = new List<GameObject>();
        
        for (int i=0; i < poolSize; i++)
        {
            
            GameObject bullet = Instantiate(bulletFactory, BulletPool);
            
            GameObject bulletL = Instantiate(bulletLFactory,BulletPool);
            
            GameObject bulletR = Instantiate(bulletRFactory,BulletPool);
            

            bulletObjectPool.Add(bullet);
            bulletLObjectPool.Add(bulletL);
            bulletRObjectPool.Add(bulletR);

            bullet.SetActive(false);
            bulletL.SetActive(false);
            bulletR.SetActive(false);
        }
        #if UNITY_ANDROID
            GameObject.Find("Joystick canvas XYBZ").SetActive(true);
        #elif UNITY_EDITOR || UNITY_STANDALONE
            GameObject.Find("Joystick canvas XYBZ").SetActive(false);
        #endif


    }
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        Fire();
        Reload();
#endif
    }

    public void Fire()
    {
        if (Input.GetButton("Fire1"))
        {
            if (curShotDelay < maxShotDelay)
                return;
            switch (power)
            {
                case 1:
                    if (bulletObjectPool.Count > 0)
                    {
                        GameObject bullet = bulletObjectPool[0];
                        bullet.SetActive(true);

                        bulletObjectPool.Remove(bullet);

                        bullet.transform.position = transform.position;
                        
                    }
                    break;
                case 2:
                    if (bulletLObjectPool.Count > 0)
                    {
                        GameObject bulletL = bulletLObjectPool[0];
                        bulletL.SetActive(true);

                        bulletLObjectPool.Remove(bulletL);

                        bulletL.transform.position = transform.position + Vector3.left * 0.4f;
                    }
                    if (bulletRObjectPool.Count > 0)
                    {
                        GameObject bulletR = bulletRObjectPool[0];
                        bulletR.SetActive(true);
                        bulletRObjectPool.Remove(bulletR);

                        bulletR.transform.position = transform.position + Vector3.right * 0.4f;
                    }
                    break;
                case 3:
                    if (bulletLObjectPool.Count > 0)
                    {
                        GameObject bulletL = bulletLObjectPool[0];
                        bulletL.SetActive(true);

                        bulletLObjectPool.Remove(bulletL);

                        bulletL.transform.position = transform.position + Vector3.left * 0.4f;
                    }
                    if (bulletRObjectPool.Count > 0)
                    {
                        GameObject bulletR = bulletRObjectPool[0];
                        bulletR.SetActive(true);
                        bulletRObjectPool.Remove(bulletR);

                        bulletR.transform.position = transform.position + Vector3.right * 0.4f;
                    }
                    if (bulletObjectPool.Count > 0)
                    {
                        GameObject bullet = bulletObjectPool[0];
                        bullet.SetActive(true);

                        bulletObjectPool.Remove(bullet);

                        bullet.transform.position = transform.position;
                    }
                    break;
                case 4:
                    if (bulletLObjectPool.Count > 0)
                    {
                        GameObject bulletL = bulletLObjectPool[0];
                        bulletL.SetActive(true);

                        bulletLObjectPool.Remove(bulletL);

                        bulletL.transform.position = transform.position + Vector3.left * 0.4f;
                    }
                    if (bulletRObjectPool.Count > 0)
                    {
                        GameObject bulletR = bulletRObjectPool[0];
                        bulletR.SetActive(true);
                        bulletRObjectPool.Remove(bulletR);

                        bulletR.transform.position = transform.position + Vector3.right * 0.4f;
                    }
                    if (bulletObjectPool.Count > 0)
                    {
                        GameObject bullet = bulletObjectPool[0];
                        bullet.SetActive(true);

                        bulletObjectPool.Remove(bullet);

                        bullet.transform.position = transform.position;
                    }
                    if (bulletLObjectPool.Count > 0)
                    {
                        GameObject bulletL = bulletLObjectPool[0];
                        bulletL.SetActive(true);

                        bulletLObjectPool.Remove(bulletL);

                        bulletL.transform.position = transform.position + Vector3.left * 0.2f;
                    }
                    if (bulletRObjectPool.Count > 0)
                    {
                        GameObject bulletR = bulletRObjectPool[0];
                        bulletR.SetActive(true);
                        bulletRObjectPool.Remove(bulletR);

                        bulletR.transform.position = transform.position + Vector3.right * 0.2f;
                    }
                    break;
                case 5:
                    if (bulletLObjectPool.Count > 0)
                    {
                        GameObject bulletL = bulletLObjectPool[0];
                        bulletL.SetActive(true);

                        bulletLObjectPool.Remove(bulletL);

                        bulletL.transform.position = transform.position + Vector3.left * 0.4f;
                    }
                    if (bulletRObjectPool.Count > 0)
                    {
                        GameObject bulletR = bulletRObjectPool[0];
                        bulletR.SetActive(true);
                        bulletRObjectPool.Remove(bulletR);

                        bulletR.transform.position = transform.position + Vector3.right * 0.4f;
                    }
                    if (bulletObjectPool.Count > 0)
                    {
                        GameObject bullet = bulletObjectPool[0];
                        bullet.SetActive(true);

                        bulletObjectPool.Remove(bullet);

                        bullet.transform.position = transform.position;
                    }
                    if (bulletLObjectPool.Count > 0)
                    {
                        GameObject bulletL = bulletLObjectPool[0];
                        bulletL.SetActive(true);

                        bulletLObjectPool.Remove(bulletL);

                        bulletL.transform.rotation = Quaternion.Euler(0f, 0f, 45f);
                        bulletL.transform.position = transform.position + Vector3.left * 0.2f;
                        
                    }
                    if (bulletRObjectPool.Count > 0)
                    {
                        GameObject bulletR = bulletRObjectPool[0];
                        bulletR.SetActive(true);
                        bulletRObjectPool.Remove(bulletR);
                        bulletR.transform.rotation = Quaternion.Euler(0f, 0f, -45f);
                        bulletR.transform.position = transform.position + Vector3.right * 0.2f;
                        
                        
                    }
                    break;
            }
            curShotDelay = 0;
        }
    }
    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }
}
