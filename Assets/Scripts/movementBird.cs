using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;


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
    public GameObject pnlPause;


    //Declare an int variable named score
    int score = 0;
    //Declare a public Text variable
    public Text scoreText;
    public Text scoreGame;

    public Text bestScore;
    bool freez;

    int gameover;
    int best;

    bool pause;

     string m_Path;
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
             StartCoroutine(deathCoroutine());
             Score();
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
    
    IEnumerator deathCoroutine()
    {
        yield return new WaitForSeconds(1);
       Freeze();
    }

    IEnumerator SpeedGame()
    {
        yield return new WaitForSeconds(10);
       speed +=0.1f;
    }

    public void UnFreeze(){
        Time.timeScale = 1;

    }
    public void Freeze(){
        Time.timeScale = 0;
    }

    public void Replay()
    {
        //This line changes the scene to the Scene 0 in your build settings
        SceneManager.LoadScene(0);
    }
    // Start is called before the first frame update
    void Start()
    {
                //Get the path of the Game data folder

        // m_Path = Application.dataPath + "/bestScore.txt";

        //Output the Game data path to the console

        // Debug.Log("dataPath : " + m_Path );

        //     string path = m_Path;
        //     StreamReader reader = new StreamReader(path);
        //     bestScore.text = reader.ReadToEnd().ToString();
        //     reader.Close();
        if(PlayerPrefs.GetString("best") != null)
        {
            Debug.Log(PlayerPrefs.GetString("best",bestScore.text));
        bestScore.text =  PlayerPrefs.GetString("best",bestScore.text);
        }
        else
        {
            Debug.Log(PlayerPrefs.GetString("best",bestScore.text));
        bestScore.text =  PlayerPrefs.GetString("best","0");
        }

        Time.timeScale = 0;
        //Get a reference to the Rigidbody2D of the Bird
        rb2d = GetComponent<Rigidbody2D>();
        //Go right
        rb2d.velocity = Vector2.right * speed *Time.deltaTime;
        
    }
      public void reset()
    {
            // string path =m_Path;        
            // string strFile = File.ReadAllText(path);
            // strFile = strFile.Replace(bestScore.text,"0");
            // File.WriteAllText(path, strFile);
            // bestScore.text = "0";
        PlayerPrefs.SetString("best","0");
        bestScore.text =  PlayerPrefs.GetString("best","0");
    }
        private void Score()
    {
        scoreGame.text= scoreText.text;
        gameover = int.Parse(scoreGame.text);
        best = int.Parse(bestScore.text);
        if( gameover > best )
        {
            // print("ok");
            // string path =m_Path;        
            // string strFile = File.ReadAllText(path);
            // strFile = strFile.Replace(bestScore.text,scoreGame.text);
            // File.WriteAllText(path, strFile);
            // bestScore.text = scoreGame.text;*
            PlayerPrefs.SetString("best",scoreGame.text);
            bestScore.text = PlayerPrefs.GetString("best");
        }
        else
        {
            // print("ok2");
            // string path = m_Path;
            // StreamReader reader = new StreamReader(path);
            // //Print the text from the file
            // bestScore.text = reader.ReadLine().ToString();
            // reader.Close();
            bestScore.text = PlayerPrefs.GetString("best");
        }
    }

 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isDead)
        {
            //Reset Velocity
            rb2d.velocity = Vector2.right * speed * Time.deltaTime;
            //Add up force to bird
            rb2d.AddForce(Vector2.up * flapforce);        
        }
        if(Input.GetMouseButtonDown(1) && !isDead)
        {
            //Reset Velocity
            rb2d.velocity = Vector2.right * speed * Time.deltaTime;
            //Add up force to bird
            rb2d.AddForce(Vector2.up * flapforce * 2);        
        }
        if(Input.GetKeyDown(KeyCode.Space) && freez == false)
        {
            freez =true;
            pnlPause.SetActive(true);
            Freeze();
        }else if(Input.GetKeyDown(KeyCode.Space) && freez == true)
        {
            freez = false;
            pnlPause.SetActive(false);
            UnFreeze();
        }
           StartCoroutine(SpeedGame());
        
    }
    public void ExitGame()
    {
        // EditorApplication.isPlaying = false;
       Application.Quit();

    }
}
