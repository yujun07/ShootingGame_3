using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy
{
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()
    {
        GameObject target = GameObject.Find("Player");
        if (target != null)
        {
            dir = target.transform.position - transform.position;

            dir.Normalize();
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
}
