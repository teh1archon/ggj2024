using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthScript : MonoBehaviour
{
    public TextMeshPro hp;
    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        hp.text = "HP: " + health;
    }

    public void DealDamage(int damage)
    {
        Debug.Log("Player dealt damage: " + damage);
        health -= damage;
        hp.text = "HP: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
