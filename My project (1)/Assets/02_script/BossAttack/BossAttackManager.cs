using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAttackManager : MonoBehaviour
{
    public Slider Boss_Hp_slider;
    public Slider Player_HP_slider;

    public AnalyticsManager analyticsManager;

    bool flag = true;

    public void Boss_Hp_valueChange(float changeValue)
    {
        Boss_Hp_slider.value += changeValue;
        if (Boss_Hp_slider.value <= 0 && Player_HP_slider.value>0 && flag)
        {
            AnalyticsManager.Instance.LogStageClear("not_an_ending");
            flag = false;
        }
        else
        {
            Debug.Log("보스피격");
        }
    }
}
