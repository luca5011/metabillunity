using UnityEngine;
using UnityEngine.UI;
public class newblock : MonoBehaviour
{
    public Slider HP_slider;
    public GameObject hide;
    public GameObject secret;
    public GameObject recover;
    public GameObject recover2;
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
            recover.SetActive(true);
            recover2.SetActive(true);
        }
    }
}
