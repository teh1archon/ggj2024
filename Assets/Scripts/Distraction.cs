using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distraction : MonoBehaviour
{

    SpriteRenderer rd;

    void Start()
    {
        rd = GetComponent<SpriteRenderer>();
    }

    public void Show()
    {
        rd.color = Color.white;
        visibility = 1f;
    }

    public void Hide()
    {
        //rd.color = Color.clear;
    }

    private float visibility = 0;
    // Update is called once per frame
    void Update()
    {
        if (visibility > 0)
        {
            visibility -= 0.005f;
        }

        Color newColor = new Color(1f, 1f, 1f, visibility); //
        rd.color = newColor;
    }
}
