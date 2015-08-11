using UnityEngine;
using System.Collections;

public class Vital : ModifiedStat
{
    private int _curValue;

    public Vital()
    {
        _curValue = 0;
        ExpToLevel = 0;
        LevelModifier = 1.1f;
    }

    public int CurValue
    {
        get
        {
            if (_curValue > AdjustBaseValue)
            {
                _curValue = AdjustBaseValue;
            }
            return _curValue;
        }
    
        set { _curValue = value; }
    }



}

public enum VitalName
{
    Health,
    Energy,
    Mana
}
