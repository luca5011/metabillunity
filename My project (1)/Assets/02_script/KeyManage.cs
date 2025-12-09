using System.Collections.Generic;
using UnityEngine;

public class KeyManage : MonoBehaviour
{
    public bool homeScene = false;
    public List<GameObject> KeyAfterObject = new List<GameObject>();
    void Awake()
    {
        if (homeScene)
        {
            PlayerPrefs.SetInt("Key",0);
        }
        bool status = true;
        if(PlayerPrefs.GetInt("Key") == 1)
        {
            status = false;
        }

        for(int i = 0; i < KeyAfterObject.Count; i++)
        {
            KeyAfterObject[i].SetActive(status);
        }
    }
}
