using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScrifts : MonoBehaviour
{
    [SerializeField] private AudioSource jumpSoundEffect,fireSoundEffect;
    public float movementSpeed = 1;
    public float jumpForce = 1;

    public Bullet bulletPrefab;
    public Transform lauch;
    private Rigidbody2D rigidbody;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement,0,0) * Time.deltaTime * movementSpeed;
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
            anim.SetBool("Run",true);
        }else{
            anim.SetBool("Run",false);
        }

        if(!Mathf.Approximately(0,movement))
        transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
    
        if(Input.GetKey(KeyCode.Space) && Mathf.Abs(rigidbody.velocity.y) < 0.001f){
            jumpSoundEffect.Play();
            anim.SetBool("Jump",true);
            rigidbody.AddForce(new Vector2(0, jumpForce*2), ForceMode2D.Impulse);
            Invoke("jump", 0.8f);
            
        }
        else{
            anim.SetBool("Jump",false);
            
        }
        

        if (Input.GetKey(KeyCode.S)){
            anim.SetBool("Crouch",true);
        }else{
            anim.SetBool("Crouch",false);
        }

        if(Input.GetKeyDown(KeyCode.J)){
            fireSoundEffect.Play();
        Instantiate(bulletPrefab,lauch.position,transform.rotation);
        }
        
    }

    void jump()
    {
        rigidbody.gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        rigidbody.velocity = new Vector2(0, 0);
        Invoke("waitJump", 3f);
    }

    void waitJump()
    {
        rigidbody.gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

    }
}
