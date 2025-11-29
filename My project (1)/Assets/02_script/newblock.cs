using UnityEngine;
using UnityEngine.UI;
public class newblock : MonoBehaviour
{
    public Slider HP_slider;
    public GameObject hide;
    public GameObject secret;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP_slider.value < 1)
        {
            hide.SetActive(true);
            secret.SetActive(true);

        }
    }
}
