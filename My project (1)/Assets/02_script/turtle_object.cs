using UnityEngine;

public class turtle_object : MonoBehaviour
{
    public CapsuleCollider2D circle;
    public int damage = -20;
    [Header("기본 거북이와 같은 박자일 경우 채크")]
    public bool turtle_ON_OFF = true;
    public void Turtle__ON()
    {
        if (turtle_ON_OFF == true)
        {
            circle.enabled = true;
        }
        else
        {
            circle.enabled = false;
        }
    }
    public void Turtle__OFF()
    {
        if(turtle_ON_OFF == true)
        {
            circle.enabled = false;
        }
        else
        {
            circle.enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("감지" + collision.gameObject.name);
        if (collision.gameObject.name == "player")
        {
            collision.gameObject.GetComponent<player_control>().HP_valueCHange(damage);
        }


    }
}
