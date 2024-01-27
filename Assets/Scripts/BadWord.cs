using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;



public class BadWord : MonoBehaviour
{
    void showWord()
    {
        gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    float startTime;
    float endTime;
    void Start()
    {
        gameObject.SetActive(false);
        startTime = UnityEngine.Random.value*7;
        endTime = startTime + 10f;
        Invoke("showWord", startTime);
    }

    // Update is called once per frame
    void Update()
    {
    /*    if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Clicked!");
        }*/


    }
    public void OnMouseDown()
    {
        // Actions to perform on mouse click
        Debug.Log("Mouse Clicked!");
        Destroy(gameObject);
       // UnityEngine.Object.Destroy(this);
        // ... more actions here ...
    }
}
