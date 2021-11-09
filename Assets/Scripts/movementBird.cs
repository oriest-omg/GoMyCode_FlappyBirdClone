using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementBird : MonoBehaviour
{
    Rigidbody2D rb2d;
    //public varial are editable on the inspector
    public float speed;
    //Use SerializeField to edit a variable from the inspector enven if it's praivate
    [SerializeReference]
    private float flapforce = 20f;

    //Don't forget to declare the isDead variable
    bool isDead;

    //Add an OncollisionEnter2d function to your BirdScript

    private void OnCollisionEnter2D(Collision2D other) {
        isDead = true;
        rb2d.velocity = Vector2.zero;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Get a reference to the Rigidbody2D of the Bird
        rb2d = GetComponent<Rigidbody2D>();
        //Go right
        rb2d.velocity = Vector2.right * speed *Time.deltaTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isDead)
        {
            //Reset Velocity
            rb2d.velocity = Vector2.right * speed * Time.deltaTime;
            //Add up force to bird
            rb2d.AddForce(Vector2.up * flapforce);        }
        
    }
}
