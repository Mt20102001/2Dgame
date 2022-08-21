using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private AudioSource BoomSoundEffect;
    public GameObject EnemyDestroyEffect,BulletDestroyEffect;
    public float Speed = 4.5f;
    public float SpeedReturn = 4.5f;

    public float RotationSpeed = 2.0f;
    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        SpeedReturn = Speed;
    }
    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * Speed;
        //Destroy(gameObject,1);
        Invoke("bomerang", 1f);
        
        
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.gameObject.tag == "Enemy"){
            // BoomSoundEffect.Play();
            Destroy(target.gameObject);
            Instantiate(EnemyDestroyEffect,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        if(target.gameObject.tag == "Ground"){
            Instantiate(BulletDestroyEffect,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        if(target.gameObject.tag == "Props"){
            Instantiate(BulletDestroyEffect,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        if(target.gameObject.tag == "Barrel"){
            Destroy(target.gameObject);
            Destroy(gameObject);
            Instantiate(EnemyDestroyEffect,transform.position,Quaternion.identity);
        }
        if (target.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Speed = SpeedReturn;
        }
    }

    void bomerang()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, SpeedReturn * Time.deltaTime);
        Speed = 0;
    }
}
