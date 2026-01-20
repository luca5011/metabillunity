using UnityEngine;
using UnityEngine.UI;

public class Endeventcontroller : MonoBehaviour
{
    public InputField nameinput;
    public InputField phoneinput;

    public GameObject SavePopup;

    void Start()
    {
        
    }

    public void Popup_submitBtn()
    {
        if(string.IsNullOrEmpty(nameinput.text) || string.IsNullOrEmpty(phoneinput.text))
        {
            return;
        }

        if(AnalyticsManager.Instance != null)
        {
            AnalyticsManager.Instance.LogEventEnd(nameinput.text, phoneinput.text);
            SavePopup.SetActive(true);
        }
    }
}
