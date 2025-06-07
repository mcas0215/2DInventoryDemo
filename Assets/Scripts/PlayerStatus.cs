using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    /*열정{머리띠 종류(빨간색 머리티, 파란색 머리띠, 흰색 머리띠)}
    업무 효율 { 키보드, 마우스 }
    체력{초코바}
    사회생활{꽃, 부채}

    열정: 250(0 + [형광 초록색]250)
    등등*/

    public int basePassion = 0;
    public int baseEfficiency = 0;
    public int baseHealth = 0;
    public int baseSocial = 0;

    public int totalPassion => basePassion + ItemAddStat("Passion");
    public int totalEfficiency => baseEfficiency + ItemAddStat("Efficiency");
    public int totalHealth => baseHealth + ItemAddStat("Health");
    public int totalSocial => baseSocial + ItemAddStat("Social");

    public void ItemAddStat()
    {

    }

}
