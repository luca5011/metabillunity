using UnityEngine;
using UnityEngine.UI;

public class portal : MonoBehaviour
{
    public Slider HP_slider;
    public string Nextscene;
    [Header("스테이지가 양수면 체크")]
    public bool flag = true;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            if (!flag || HP_slider.value>0)
            {
                Application.LoadLevel(Nextscene);
            }
        }


    }
}
