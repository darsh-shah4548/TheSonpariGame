using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // NEW: Face sprite references
    public Sprite birdHappy;
    public Sprite birdSad;
    private SpriteRenderer birdRenderer;

    void Start()
    {
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicScript>();
        birdRenderer = GetComponent<SpriteRenderer>();  // Get the renderer attached to the bird
        birdRenderer.sprite = birdHappy; // Start with happy face
    }

    void Update()
    {
        // Check for spacebar (desktop) or tap (mobile)
        bool flapTriggered = Input.GetKeyDown(KeyCode.Space);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            flapTriggered = true;
        }

        if (flapTriggered && birdIsAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }

        if (transform.position.y > 15 || transform.position.y < -15)
        {
            logic.gameOver();
            birdIsAlive = false;
            birdRenderer.sprite = birdSad; // Switch to sad face
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
        birdRenderer.sprite = birdSad; // Switch to sad face
    }
}
