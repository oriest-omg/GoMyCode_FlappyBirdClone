using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform birdTransform;
    Vector3 range;

    private void Awake() {
        //calculate the range between the camera's position and the bird's position
        range = transform.position - birdTransform.position;
    }

    //update is called once per frame
    private void FixedUpdate() {
        //Make the camera follow the bird's movement on the x axis
        //And keep the y position constant
        transform.position = new Vector3(range.x + birdTransform.position.x, transform.position.y, range.z + birdTransform.position.z);
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
