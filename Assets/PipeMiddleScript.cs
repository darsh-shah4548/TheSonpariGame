using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{

    public LogicScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!logic.isgameOver && collision.gameObject.layer == 3)
        {
            logic.addScore(1);
        }
        
    }
}
