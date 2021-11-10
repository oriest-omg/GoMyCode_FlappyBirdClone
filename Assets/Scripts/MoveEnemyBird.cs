using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyBird : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = speed * Vector2.left * Time.deltaTime ;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = speed * Vector2.left * Time.deltaTime ;
        
    }
    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "obs")
        {
           GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
    private void OnCollisionExit2D(Collision2D col) {
        if(col.gameObject.tag == "obs")
        {
           GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
