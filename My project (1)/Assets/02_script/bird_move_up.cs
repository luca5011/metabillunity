using UnityEngine;

public class bird_move_up : MonoBehaviour
{
    public float speed = 20.0f;
    public float move = 2.0f;

    float startY;
    int direction = 1;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {

        transform.Translate(0, speed * direction * Time.deltaTime, 0);

        // 범위를 벗어나면 방향 전환
        if (transform.position.y > startY + move)
        {
            direction = -1;
        }
        else if (transform.position.y < startY - move)
        {
            direction = 1;
        }
    }
}