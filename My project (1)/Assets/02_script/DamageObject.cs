using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public int Value_int;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("감지" + collision.gameObject.name);
        if (collision.gameObject.name == "player")
        {
            collision.gameObject.GetComponent<player_control>().HP_valueCHange(Value_int);
        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("감지" + collision.gameObject.name);
        if (collision.gameObject.name == "player")
        {
            collision.gameObject.GetComponent<player_control>().HP_valueCHange(Value_int);
        }


    }
}
