using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    public Transform AtP;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (Attack ());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Attack(){
        yield return new WaitForSeconds (Random.Range (2,8));
        Instantiate(bullet, AtP.position, Quaternion.identity);
        StartCoroutine (Attack ());
    }

    void onTriggerEnter2D(Collider2D target){
        if(target.gameObject.tag == "Player"){
            Destroy(target.gameObject);
        }
    }
}
