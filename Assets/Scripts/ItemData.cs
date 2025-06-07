using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Itemtype
{
    Passion,
    Efficiency,
    Health,
    Social
}


public class ItemData : ScriptableObject
{
    public string displayName;
    public string description;
    public Itemtype type;
    public Sprite Icon;
}
