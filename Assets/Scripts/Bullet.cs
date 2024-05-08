using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    public string Type;

    public void Move()
    {
        if (GameManager.instance.isGameover == false)
        {
            Bullet bullet = gameObject.GetComponent<Bullet>();
            Vector3 dir = Vector3.up;
            if (bullet.Type == "E")
            {
                dir = Vector3.down;
            }
            transform.Translate(dir * speed * Time.deltaTime);
        }
    }
    void Update()
    {
        Move();
    }
}
