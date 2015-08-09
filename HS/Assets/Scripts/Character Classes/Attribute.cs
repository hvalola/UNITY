using UnityEngine;
using System.Collections;

public class Attribute : BaseStat
{
    public Attribute()
    {
        ExpToLevel = 50;
        LevelModifier = 1.85f;
    }

}

public enum AttributeName
{
    Night,
    Constitution,
    Ninbleness,
    Speed,
    Concentration,
    Willpower,
    Charisma
}