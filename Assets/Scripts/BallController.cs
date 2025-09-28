using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameManager gameManager;
    public float ballSpeed = 12f;
    public float maxInitalAngle = 0.67f;
    public Vector2 startingPosisiton = Vector2.zero;
   
   void Update()
    {
        
        

    }

     public void Serve()
    {
        Vector2 direction = Vector2.left;
        if(Random.value > 0.5)
        {
            direction = Vector2.right;
        }
        direction.y = Random.Range(-maxInitalAngle, maxInitalAngle);
        rb.linearVelocity = direction * ballSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        gameManager.SetScores(collision.tag);

        if (!gameManager.CheckWin())
        {
            ResetBall();
            Invoke("Serve", 2);
        }
        
    }

    public void ResetBall()
    {
        Vector2 pos = startingPosisiton;
        Vector2 vel = Vector2.zero;
        transform.position = pos;
        rb.linearVelocity = vel;

    }
}
