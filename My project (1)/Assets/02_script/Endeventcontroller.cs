using UnityEngine;
using TMPro;

public class Endeventcontroller : MonoBehaviour
{
    public TMP_InputField nameinput;
    public TMP_InputField phoneinput;

    public GameObject SavePopup;

 

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
