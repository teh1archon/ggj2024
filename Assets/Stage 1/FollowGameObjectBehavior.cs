using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The behavior will change preserve x axis relative position 
between the object a behavior is assigned to, to other customizable object */
public class FollowGameObjectBehavior : MonoBehaviour
{
    // Variables
    public GameObject objectToFollow;
    public float xPositionOffset = 0f;
    public float yPositionOffset = 0f;
    public float zPositionOffset = -30f;

    // Start is called before the first frame update
    void Start()
    {
        // Set the position of the object to follow
        transform.position = new Vector3(
            objectToFollow.transform.position.x + xPositionOffset,
            objectToFollow.transform.position.y + yPositionOffset,
            objectToFollow.transform.position.z + zPositionOffset
        );
    }

    // Update is called once per frame
    void Update()
    {
        // Set the x position of the object to follow, leaving y and z unchanged
        transform.position = new Vector3(
            objectToFollow.transform.position.x + xPositionOffset,
            transform.position.y,
            transform.position.z
        );
    }
}
