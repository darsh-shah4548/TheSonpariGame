using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float baseMoveSpeed = 10f;
    public float deadZone = -45f;

    private bool enableVerticalMovement = false;
    private float startY;
    private float verticalAmplitude = 1.25f;
    private float verticalSpeed = 1.25f;

    private LogicScript logic;
    private int movementScoreThreshold;
    private bool movementDecided = false;

    void Start()
    {
        startY = transform.position.y;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        movementScoreThreshold = Random.Range(45, 60);
    }

    void Update()
    {
        if (logic == null) return;

        float scoreBasedBoost = logic.playerScore / 50f;
        float moveSpeed = baseMoveSpeed + scoreBasedBoost;

        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // Decide once when player crosses the threshold
        if (!movementDecided && logic.playerScore >= movementScoreThreshold)
        {
            movementDecided = true;
            enableVerticalMovement = Random.value < 0.5f;  // 50% chance to enable
        }

        if (enableVerticalMovement)
        {
            // Dynamically scale movement difficulty with score (clamped to avoid chaos)
            verticalAmplitude = Mathf.Clamp(0.5f + (logic.playerScore / 100f), 0.5f, 1.5f);
            verticalSpeed = Mathf.Clamp(1f + (logic.playerScore / 120f), 1f, 2f);

            float verticalOffset = Mathf.Sin(Time.time * verticalSpeed) * verticalAmplitude;
            transform.position = new Vector3(transform.position.x, startY + verticalOffset, transform.position.z);
        }

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
