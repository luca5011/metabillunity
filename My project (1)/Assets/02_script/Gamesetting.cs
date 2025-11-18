using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class Gamesetting : MonoBehaviour
{
    public AudioSource AudioSource_;
    
    [Header("홈씬에만 넣어주기")]
    public GameObject settingPanel;

    public Toggle UI_SoundToggle;
    public Dropdown UI_difficultyDropdown;

    
    
    void Start()
    {
        SettingDataRead();
        SoundStatusSet();
    }

    void SettingDataSave()
    {
        PlayerPrefs.SetString("sound", UI_SoundToggle.ToString());
        PlayerPrefs.SetString("difficulty",UI_difficultyDropdown.value.ToString());

    }
    public void SettingDataRead()
    {
        Debug.Log("Sound : " + PlayerPrefs.GetString("sound"));
        Debug.Log("difficulty : " + PlayerPrefs.GetString("difficulty"));
    }

    public void ToggleValueChange()
    {
        PlayerPrefs.SetString("sound", UI_SoundToggle.isOn.ToString());
        Debug.Log("sound 수정 : " + PlayerPrefs.GetString("sound"));
        SoundStatusSet();
    }

    public void DropdownValueChange()
    {
        PlayerPrefs.SetString("difficulty", UI_difficultyDropdown.value.ToString());
        Debug.Log("difficulty 수정 : " + PlayerPrefs.GetString("difficulty"));
    }


    void SoundStatusSet()
    {
        if(PlayerPrefs.GetString("sound") == "False")
        {
            AudioSource_.volume = 0;
        }
        else
        {
            AudioSource_.volume = 1;
        }
    }
    public void SettingPanel(bool status)
    {
        settingPanel.SetActive(status);
    }
}
