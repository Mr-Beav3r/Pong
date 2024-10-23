using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    Vector2 direction;
    float speed = 8.0f;
    BoxCollider2D Player1Box;
    BoxCollider2D Player2Box;
    BoxCollider2D BallBox;
    int Player1Score = 0;
    int Player2Score = 0;
   
    void Start()
    {
        float angle = 30.0f * Mathf.Deg2Rad;
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        transform.position = Vector3.zero;

        Player1Box = Player1.GetComponent<BoxCollider2D>();
        Player2Box = Player2.GetComponent<BoxCollider2D>();
        BallBox = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // Handle wall collisions
        if (transform.position.x > 11.0f || transform.position.x < -11.0f)
        {
            direction.x = -direction.x;
        }
        if (transform.position.y > 5.0f || transform.position.y < -5.0f)
        {
            direction.y = -direction.y;
        }

        float dt = Time.deltaTime;
        Vector3 change = direction * speed * dt;
        transform.position += change;

        // Player 1 measurements
        float xP1 = Player1Box.transform.position.x;
        float yP1 = Player1Box.transform.position.y;
        float hwP1 = Player1Box.size.x * Player1.transform.localScale.x * 0.5f;
        float hhP1 = Player1Box.size.y * Player1.transform.localScale.y * 0.5f;
        float xMinP1 = xP1 - hwP1;
        float xMaxP1 = xP1 + hwP1;
        float yMinP1 = yP1 - hhP1;
        float yMaxP1 = yP1 + hhP1;

        // Player 2 measurements
        float xP2 = Player2Box.transform.position.x;
        float yP2 = Player2Box.transform.position.y;
        float hwP2 = Player2Box.size.x * Player2.transform.localScale.x * 0.5f;
        float hhP2 = Player2Box.size.y * Player2.transform.localScale.y * 0.5f;
        float xMinP2 = xP2 - hwP2;
        float xMaxP2 = xP2 + hwP2;
        float yMinP2 = yP2 - hhP2;
        float yMaxP2 = yP2 + hhP2;

        // Ball measurements
        float XBall = BallBox.transform.position.x;
        float YBall = BallBox.transform.position.y;
        float hwBall = BallBox.size.x * BallBox.transform.localScale.x * 0.5f;
        float hhBall = BallBox.size.y * BallBox.transform.localScale.x * 0.5f;
        float xMinBall = XBall - hwBall;
        float xMaxBall = XBall + hwBall;
        float yMinBall = YBall - hhBall;
        float yMaxBall = YBall + hhBall;

        if ((xMinBall < xMaxP1 && xMaxBall > xMinP1 && yMinBall < yMaxP1 && yMaxBall > yMinP1) ||
            (xMinBall < xMaxP2 && xMaxBall > xMinP2 && yMinBall < yMaxP2 && yMaxBall > yMinP2))
        {
            direction.x = -direction.x;
        }

        if (XBall < -11.0f)
        {
            Player2Score++;
            Debug.Log("Player2Score: " + Player2Score);
        }
        if (XBall > 11.0f)
        {
            Player1Score++;
            Debug.Log("Player1Score: " + Player1Score);
        }
    }
}