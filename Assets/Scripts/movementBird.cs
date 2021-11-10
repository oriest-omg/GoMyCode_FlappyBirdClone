using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


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
    //Add a public GameObject variable and drag your Button in the Inspector
    public GameObject pnlGameOver;

    //Declare an int variable named score
    int score = 0;
    //Declare a public Text variable
    public Text scoreText;
    //Add an OncollisionEnter2d function to your BirdScript
    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag != "dontUp")
        {
        isDead = true;
        rb2d.velocity = Vector2.zero;
        //set the ReplayButton to active to show it in the scene
        pnlGameOver.SetActive(true);

        //change the isDead parameter of the Animator to start the Dead animation
        GetComponent<Animator>().SetBool("isDead",true);
        }

    }
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Score")
         {
             //Increment score
             score++;
             //Show the score in the console
             Debug.Log(score);
             //update Text
             scoreText.text = score.ToString();
         }
    }

    public void UnFreeze(){
        Time.timeScale = 1;
        scoreText.text = "0";

    }

    public void Replay()
    {
        //This line changes the scene to the Scene 0 in your build settings
        SceneManager.LoadScene(0);
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
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
