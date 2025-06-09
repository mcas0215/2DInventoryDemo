using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum StatType
  {
      Passion,
      Efficiency,
      Health,
      Social
  }

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

    public int totalPassion => basePassion + ItemAddStat(StatType.Passion);
    public int totalEfficiency => baseEfficiency + ItemAddStat(StatType.Efficiency);
    public int totalHealth => baseHealth + ItemAddStat(StatType.Health);
    public int totalSocial => baseSocial + ItemAddStat(StatType.Social);

    public int ItemAddStat(StatType stat)
    {
        int total = 0;
        foreach (var item in equippedItems)
        {
            if (item.bonusStats.TryGetValue(stat, out int bonus))
            {
                total += bonus;
            }
        }
        return total;
    }

    public int GetBaseStat(StatType type)
    {
        return type switch
        {
            StatType.Passion => basePassion,
            StatType.Efficiency => baseEfficiency,
            StatType.Health => baseHealth,
            StatType.Social => baseSocial,
            _ => 0
        };
    }

    public int GetBonusStat(StatType stat) => ItemAddStat(stat);

    public int GetTotalStat(StatType stat) => GetBaseStat(stat) + GetBonusStat(stat);

}
