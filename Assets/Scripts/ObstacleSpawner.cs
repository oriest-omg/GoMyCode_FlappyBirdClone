using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float minY;
    public float maxY;
    public float distance;

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Obstacle")
        {
            //choose random Y position
            float obstacleY = Random.Range(minY,maxY);
            //choose a postion for the new obstacle
            Vector3 spawnPosition = new Vector3(transform.position.x + distance,obstacleY,0);
            //Move Obstacle to SpawnPosition
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
