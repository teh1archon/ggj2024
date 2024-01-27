using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorScript : MonoBehaviour
{
    // Variables
    public float speed = 25f;
    public float jumpHeight = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ReceiveSignal(string signalValue)
    {
        Debug.Log("Player received signal: " + signalValue);
        if(signalValue == "deal damage")
        {
            // Deal damage to the player
            GetComponent<HealthScript>().DealDamage(1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        float speedForCalculation = speed;
        
        // Or right arrow or "D" key, move right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            // Move right
            transform.position += Vector3.right * speed * Time.deltaTime;
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }

        // Or left arrow or "A" key, move left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            // Move left
            transform.position += Vector3.left * speed * Time.deltaTime;
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        
        // Jump if space bar, up arrow, or "W" key is pressed
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            // Jump
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpHeight;
        }

        // If down arrow or "S" key is pressed, move down
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            // Move down
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }
}
