using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float minY;
    public float maxY;
    public float distance;

    private void OnTriggerEnter2D(Collider2D col) {
        Vector3 obsPosition = Vector3.zero;
        if(col.tag == "Obstacle" && col.name != "flame" )
        {
            //choose random Y position
            float obstacleY = Random.Range(minY,maxY);
            //choose a postion for the new obstacle
            // Vector3 spawnPosition = new Vector3(transform.position.x + distance,obstacleY,0);
            Vector3 spawnPosition = new Vector3(col.transform.position.x + 19,obstacleY,0);
            //Move Obstacle to SpawnPosition
            col.gameObject.transform.position = spawnPosition;
            obsPosition = spawnPosition;
        } 
        if( col.tag == "Obstacle" && col.name == "flame" )
        {
            // print("flame");
            //choose random Y position
            float obstacleY = Random.Range(-1.6318f,1.05f);
            //choose a postion for the new obstacle
            Vector3 spawnPosition = new Vector3(col.transform.position.x + 19 ,obstacleY,0);
            float randScaly = Random.Range(0.7129308f,1.05f);
            // col.gameObject.GetComponent<SpriteRenderer>().flipY = (Random.value > 0.5f);
            //Move Obstacle to SpawnPosition
            col.gameObject.transform.localScale = new Vector2(0.2059059f,randScaly);
            col.gameObject.transform.position = spawnPosition;
        }        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
