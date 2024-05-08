using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!GameManager.instance.isGameover)
        {
            if (other.gameObject.tag=="Bullet" || other.gameObject.tag=="Enemy" || other.gameObject.tag == "Item")
            {
                other.gameObject.SetActive(false);
                if (other.gameObject.tag=="Bullet")
                {
                    Bullet bullet = other.gameObject.GetComponent<Bullet>();
                    PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
                    switch (bullet.Type)
                    {
                        case "Bullet":
                            player.bulletObjectPool.Add(other.gameObject);
                            other.gameObject.SetActive(false);
                            break;
                        case "BulletL":
                            player.bulletLObjectPool.Add(other.gameObject);
                            other.gameObject.SetActive(false);
                            break;
                        case "BulletR":
                            player.bulletRObjectPool.Add(other.gameObject);
                            other.gameObject.SetActive(false);
                            break;
                    }
                }
                else if (other.gameObject.tag == "Enemy")
                {
                    GameObject emObject = GameObject.Find("EnemyManager");

                    EnemyManager manager = emObject.GetComponent<EnemyManager>();

                    manager.enemyObjectPool.Add(other.gameObject);
                }
                else if (other.gameObject.tag == "Item")
                {
                    GameObject itmObject = GameObject.Find("ItemManager");

                    ItemManager itmManager = itmObject.GetComponent<ItemManager>();
                    other.gameObject.SetActive(false);
                    itmManager.itemObjectPool.Add(other.gameObject);
                }
            }
        }
    }
}
