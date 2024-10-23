using UnityEngine;

public class Player1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction = Vector2.down;
        }

        float dt = Time.deltaTime;
        float speed = 8.0f;
        Vector3 change = direction * speed * dt;
        transform.position = transform.position + change;


    }
}
