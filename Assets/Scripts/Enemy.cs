using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    
    public GameObject explosionFactory;
    void OnCollisionEnter(Collision other)
    {
        GameObject GameManagerObject = GameObject.Find("GameManager");
        GameManager gm = GameManagerObject.GetComponent<GameManager>();

        GameObject emObject = GameObject.Find("EnemyManager");
        EnemyManager manager = emObject.GetComponent<EnemyManager>();


        if (GameManager.instance.isGameover == false)
        {
            if (other.gameObject.tag == "Bullet")
            {
                
                other.gameObject.SetActive(false);
                Bullet bullet = other.gameObject.GetComponent<Bullet>();
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
                switch (bullet.Type)
                {
                    case "Bullet":
                        player.bulletObjectPool.Add(other.gameObject);
                        break;
                    case "BulletL":
                        player.bulletLObjectPool.Add(other.gameObject);
                        break;
                    case "BulletR":
                        player.bulletRObjectPool.Add(other.gameObject);
                        break;
                }
                gameObject.SetActive(false);
                GameObject explosion = Instantiate(explosionFactory);
                explosion.transform.position = transform.position;
                manager.enemyObjectPool.Add(gameObject);
                GameManager.instance.Score++;
            }
            
        }
    }
   
    void Update()
    {
        
    }
}
