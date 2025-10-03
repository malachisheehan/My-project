using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public Rigidbody2D rb;
    public int playerId;
    public float moveSpeed = 5f;
    private Vector2 startPosition;
    //public Transform ball;


    // Update is called once per frame
    void Update()
    {
        if(playerId == 2 && GameManager.Instance.playMode == GameManager.PlayMode.PlayerVsCPU)
        {
            MoveCPU();
        }

        else
        {
            float axisValue = GetAxisValue();
            MovePaddle(axisValue);
        }
            
    }

    private void OnEnable()
    {
        startPosition = transform.position;
    }

    private void MoveCPU()
    {
        Vector2 ballPosition = ball.transform.position;
        transform.position = new Vector2(startPosition.x, ballPosition.y);
    }

    private void MovePaddle(float axisValue)
    {
        Vector2 velocity = rb.linearVelocity;
        velocity.y = axisValue * moveSpeed;
        rb.linearVelocity = velocity;
    }

    private float GetAxisValue()
    {
        float axisValue = 0f;
        if (playerId == 1)
            axisValue = Input.GetAxis("PaddlePlayer1");
        if (playerId == 2)
            axisValue = Input.GetAxis("PaddlePlayer2");
        return axisValue;
    }
}
