using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public GameObject EnemyDestroyEffect;

    void onTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Bullet"){
            Instantiate(EnemyDestroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
