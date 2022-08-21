using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScrift : MonoBehaviour
{
    public float moveForce = 5;
    public float jumpForce = 1;
    public float maxVelocity = 2;

    private bool grounded;
    private Rigidbody2D myBody;
    private Animator anim;
    public Bullet bulletPrefab;
    public Transform lauch;

    void Awake(){
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRunKeyboard();
        if(Input.GetKeyDown(KeyCode.J)){
            Instantiate(bulletPrefab,lauch.position,transform.rotation);
        }
        if(Input.GetKey(KeyCode.Space) && Mathf.Abs(myBody.velocity.y) < 0.001f){
            myBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void PlayerRunKeyboard(){
        float forceX = 0f;
        float forceY = 0f;

        float vel = Mathf.Abs (myBody.velocity.x);

        float h = Input.GetAxisRaw ("Horizontal");
        if(h > 0){
            if(vel < maxVelocity){
                if(grounded==true){
                    forceX = moveForce;
                }else{
                    forceX = moveForce * 1.1f;
                }
            }

            Vector3 scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;

            anim.SetBool ("Run",true);
        }else if( h < 0){
            if(vel < maxVelocity){
                if(grounded==true){
                    forceX = -moveForce;
                }else{
                    forceX = -moveForce * 1.1f;
                }
            }

            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;

            anim.SetBool ("Run",true);
        }else if(h == 0){
            anim.SetBool("Run",false);
        }

        if(Input.GetKey(KeyCode.Space)){
            if(grounded){
                grounded = false;
                forceY = jumpForce;
            }
        }

        myBody.AddForce(new Vector2 (forceX,forceY));
    }
    void OnCollisionEnter2D(Collision2D target){
        if(target.gameObject.name == "Ground"){
            grounded = true;
        }
    }
}
