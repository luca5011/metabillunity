using UnityEngine;

public class bird_move : MonoBehaviour
{
    public float speed = 20.0f;
    public float move = 2.0f;

    float startX;
    int direction = 1;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        transform.Translate(speed * direction * Time.deltaTime, 0, 0);

        // 범위를 벗어나면 방향 전환
        if (transform.position.x > startX + move)
        {
            direction = -1;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (transform.position.x < startX - move)
        {
            direction = 1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}