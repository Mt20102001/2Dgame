using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    public int speed = 1;
    void Update()
    {
            transform.Translate(Vector3.left*speed*Time.deltaTime,Space.World);
            Destroy(gameObject,1);
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.gameObject.tag == "Player"){
            Destroy(target.gameObject);
            Destroy(gameObject);
        }
        if(target.gameObject.tag == "Ground"){
            Destroy(gameObject);
        }
        if(target.gameObject.tag == "Barrel"){
            Destroy(gameObject);
        }
        if(target.gameObject.tag == "Props"){
            Destroy(gameObject);
        }
    }
}
