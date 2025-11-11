using UnityEngine;

public class turtle_object : MonoBehaviour
{
    public CapsuleCollider2D circle;
    public void Turtle__ON()
    {
        circle.enabled = true;
    }
    public void Turtle__OFF()
    {
        circle.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("°¨Áö" + collision.gameObject.name);
        if (collision.gameObject.name == "player")
        {
            collision.gameObject.GetComponent<player_control>().HP_valueCHange(20);
        }


    }
}
