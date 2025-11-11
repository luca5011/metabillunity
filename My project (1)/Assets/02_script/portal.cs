using UnityEngine;

public class portal : MonoBehaviour
{
    public string Nextscene;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            Application.LoadLevel(Nextscene);
        }


    }
}
