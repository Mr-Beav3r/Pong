using UnityEngine;

public class Player2 : MonoBehaviour
{
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }

        float dt = Time.deltaTime;
        float speed = 8.0f;
        Vector3 change = direction * speed * dt;
        transform.position = transform.position + change;
    }
}
