using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public Camera activeCamera;
    public float speed = 5f;  // Adjust movement speed here

    private Rigidbody2D rb2d;
    private Camera mainCamera;

    private SpriteRenderer spriteRenderer;
    private Sprite[] Sprites;
    private int currentSpriteIndex = 0;

    public GameObject Orange;
    public GameObject Falafel;
    public GameObject Grapes;
    public GameObject Hala;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;

        spriteRenderer = GetComponent<SpriteRenderer>();
        // playerSprites = new Sprite[] {Girl1,Girl2 };

    }

    void Update()
    {

        // Check for arrow key clicks
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovePlayer(-1); // Move left
         //   spriteRenderer.sprite = Resources.Load<Sprite>("Character2");
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovePlayer(1); // Move right
                           //  spriteRenderer.sprite = Resources.Load<Sprite>("Character1");
            spriteRenderer.flipX = false;


        }
    }

    void MovePlayer(float direction)
    {
        rb2d.velocity = new Vector2(direction * speed, rb2d.velocity.y);

        // Clamp player position within screen bounds
        Vector3 playerPosition = transform.position;
        float cameraRightEdge = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        float cameraLeftEdge = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;

        playerPosition.x = Mathf.Clamp(playerPosition.x, cameraLeftEdge, cameraRightEdge);
        transform.position = playerPosition;
    }

    void HideFalafel()
    {
        Falafel.SendMessage("Hide");
    }

    void HideOrange()
    {
        Orange.SendMessage("Hide");
    }

    void HideGrapes()
    {
        Grapes.SendMessage("Hide");
    }

    void HideHala()
    {
        Hala.SendMessage("Hide");
    }

    static int cntr = 0;
    private void OnParticleCollision(GameObject gameObject)
    {
        if (gameObject.CompareTag("Falafel"))
        {
            Falafel.SendMessage("Show");
            Invoke("HideFalafel", 2);
            Debug.Log("Particle collision detected with: Falafel " + cntr);
            ++cntr;
        }

        if (gameObject.CompareTag("Orange"))
        {
            Orange.SendMessage("Show");
            Invoke("HideOrange", 2);
            Debug.Log("Particle collision detected with: Orange " + cntr);
            ++cntr;
        }

        if (gameObject.CompareTag("Grapes"))
        {
            Grapes.SendMessage("Show");
            Invoke("HideGrapes", 2);
            Debug.Log("Particle collision detected with: Grapes " + cntr);
            ++cntr;
        }


        if (gameObject.CompareTag("Hala"))
        {
            Hala.SendMessage("Show");
            Invoke("HideHala", 2);
            Debug.Log("Particle collision detected with: Hala " + cntr);
            ++cntr;
        }
    }
}
