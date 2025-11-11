using Unity.VisualScripting;
using UnityEngine;

public class Apple_object : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("°¨Áö" + collision.gameObject.name);
        if (collision.gameObject.name == "player")
        {
            collision.gameObject.GetComponent<player_control>().HP_valueCHange(7);

            Destroy(this.gameObject);
        }


    }
}
