using UnityEngine;

public class recovery_object : MonoBehaviour
{
    public int Value_int;
    public bool Distroy_Set = false;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("감지" + collision.gameObject.name);
        if (collision.gameObject.name == "player")
        {
            if(collision.gameObject.GetComponent<player_control>().HP_slider.value == 0)
            {
                collision.gameObject.GetComponent<player_control>().HP_valueCHange(Value_int);
                collision.gameObject.GetComponent<player_control>().GameOverPannel.SetActive(false);
            }
            else
            {
                collision.gameObject.GetComponent<player_control>().HP_valueCHange(Value_int);
            }
            if (Distroy_Set)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("감지" + collision.gameObject.name);
        if (collision.gameObject.GetComponent<player_control>().HP_slider.value == 0)
        {
            collision.gameObject.GetComponent<player_control>().HP_valueCHange(Value_int);
            collision.gameObject.GetComponent<player_control>().GameOverPannel.SetActive(false);
        }
        else
        {
            collision.gameObject.GetComponent<player_control>().HP_valueCHange(Value_int);

        }
        if (Distroy_Set)
        {
            Destroy(this.gameObject);
        }
    }
}
