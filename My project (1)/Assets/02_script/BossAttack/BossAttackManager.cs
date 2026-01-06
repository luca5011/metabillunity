using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAttackManager : MonoBehaviour
{
    public Slider Boss_Hp_slider;
    public Slider Player_HP_slider;

    public void Boss_Hp_valueChange(float changeValue)
    {
        Boss_Hp_slider.value += changeValue;
        if (Boss_Hp_slider.value <= 0 && Player_HP_slider.value>0)
        {
            Debug.Log("보스죽음");
            Application.LoadLevel("not_an_ending");
        }
        else
        {
            Debug.Log("보스피격");
        }
    }
}
