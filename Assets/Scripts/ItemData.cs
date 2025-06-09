using System;
using System.Collections.Generic;
using UnityEngine;

public enum Itemtype
{
    Passion,
    Efficiency,
    Health,
    Social
}

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/ItemData")]
public class ItemData : ScriptableObject
{
    public string displayName;
    [TextArea]
    public string description;
    public Itemtype type;
    public Sprite Icon;

    public List<StatBonus> bonusStats = new List<StatBonus>();
}

[Serializable]
public class StatBonus
{
    public StatType stat;
    public int amount;
}

