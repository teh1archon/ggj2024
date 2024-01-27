using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndStage : MonoBehaviour
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
            SceneManager.LoadScene(1);
        }
    }
}
