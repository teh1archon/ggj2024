using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene3GameManager : MonoBehaviour
{
    public GameObject[] thoughts;
    int numOfThoughts;
    // Start is called before the first frame update
    void Start()
    {
        numOfThoughts = thoughts.Length;
    }

    public void RemoveThought()
    {
        numOfThoughts--;

        if (numOfThoughts == 0)
        {
            Debug.LogError("yay!");
            Invoke("LastScene", 2);
        }
        else
        {
            Debug.LogError(numOfThoughts);
        }
    }

    public void LastScene()
    {
        SceneManager.LoadScene(3);
    }
}
