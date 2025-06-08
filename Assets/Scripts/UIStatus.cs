using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Serialization;

public class UIStatus : MonoBehaviour
{
    public TMP_Text passionText;
    public TMP_Text efficiencyText;
    public TMP_Text healthText;
    public TMP_Text socialText;

    private PlayerStatus status;

    private Dictionary<StatType, TMP_Text> statTextMap;

    private void Start()
    {
        status = FindObjectOfType<PlayerStatus>();

        statTextMap = new Dictionary<StatType, TMP_Text>
        {
            { StatType.Passion, passionText },
            { StatType.Efficiency, efficiencyText },
            { StatType.Health, healthText },
            { StatType.Social, socialText },
        };
    }

    private void Update()
    {
        if (status == null) return;

        foreach (var pair in statTextMap)
        {
            StatType type = pair.Key;
            TMP_Text text = pair.Value;

            int baseValue = status.GetBaseStat(type);
            int bonusValue = status.GetBonusStat(type);
            int totalValue = status.GetTotalStat(type);

            text.text = $"{type}: {totalValue} ({baseValue} + <color=#00FF00>{bonusValue}</color>)";
        }
    }
}

