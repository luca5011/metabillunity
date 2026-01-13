using UnityEngine;

public class Keyobject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);
        PlayerPrefs.SetInt("Key", 1);

        Application.LoadLevel("Game_1");
    }
}
