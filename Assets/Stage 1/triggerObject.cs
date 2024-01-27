using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Once the player enters the trigger, the specified game object will be signaled.
public class triggerObject : MonoBehaviour
{
    // Variables
    public GameObject objectToTrigger;
    public String whoTriggers = "Player";
    public String signalValue = "";
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player enters the trigger
        if (other.gameObject.CompareTag(whoTriggers))
        {
            // Signal the object to start moving
            objectToTrigger.SendMessage("ReceiveSignal", signalValue);
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
