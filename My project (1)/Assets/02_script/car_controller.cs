using UnityEngine;

public class car_controller : MonoBehaviour
{
    public float speed = 10.0f;
    Vector2 starPos;
    Vector3 starpos11;
    AudioSource audioSource_;
    void Awake()
    {
        Debug.Log("awake");
    }
    void Start()
    {
        Debug.Log("start");
        audioSource_ = gameObject.GetComponent<AudioSource>();
        starpos11 = transform.position;
    }
    void Update()
    {

        if (speed >= 10.0f)
        {
            this.gameObject.transform.localEulerAngles = new Vector3(0, 0, 180);

        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.starPos = Input.mousePosition;

            }
            else if (Input.GetMouseButtonUp(0))
            {
                Vector2 endPos = Input.mousePosition;
                float swipe = endPos.x - starPos.x;
                speed = swipe / 200.0f;
                Debug.Log(speed);
                audioSource_.Play();
            }
            transform.Translate(this.speed, 0, 0);
            speed *= 0.98f;
        }
    }

    //리셋 버튼
    public void reset()
    {
        speed = 0.0f;
        transform.localEulerAngles = new Vector3(0, 0, 0);
        transform.position = starpos11;
    }
}
