using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Once a message received, the behaviour advances the object in the direction of the objectToFollow with speed "speed" */
public class pursueOtherObject : MonoBehaviour
{
    public GameObject objectToFollow;
    public float speed = 7.5f;
    public bool isFollowing = false;
    public bool followByDistance = false;
    public float distanceToFollow = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ReceiveSignal(string signalValue)
    {
        // Signal received
        Debug.Log("Signal received: " + signalValue);
        if(signalValue == "start")
        {
            isFollowing = true;
        }
        else if(signalValue == "stop")
        {
            isFollowing = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (followByDistance)
        {
            // If the object to follow is within the distance to follow, follow it
            if (Vector3.Distance(transform.position, objectToFollow.transform.position) < distanceToFollow)
            {
                isFollowing = true;
            }
            else
            {
                isFollowing = false;
            }   
        }

        if (isFollowing)
        {
            // Move rigid body towards the object to follow
            GetComponent<Rigidbody2D>().velocity = (objectToFollow.transform.position - transform.position).normalized * speed;
            
            // Point right to the object to follow
            if (objectToFollow.transform.position.x > transform.position.x)
            {
                // Look right
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                // Look left
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}
