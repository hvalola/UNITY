using UnityEngine;
using System.Collections;

public class BaseStat : MonoBehaviour {
    private int _baseValue;
    private int _buffValue;
    private int _expToLevel;
    private float _levelModifier;
    
    public BaseStat()
    {
        _baseValue = 0;
        _buffValue = 0;
        _levelModifier = 1.1f;
        _expToLevel = 100;
    }

#region Basic Setters and getters
    public int BaseValue
    {
        get { return _baseValue; }
        set { _baseValue = value; }
    }

    public int BuffValue
    {
        get { return _buffValue; }
        set { _buffValue = value; }
    }

    public float LevelModifier
    {
        get { return _levelModifier; }
        set { _levelModifier = value; }
    }

    public int ExpToLevel
    {
        get { return _expToLevel; }
        set { _expToLevel = value; }
    }
#endregion

    private int calculateExpToLevel()
    {
        return(int)( _expToLevel * _levelModifier);
    }

    public void LevelUp()
    {
        _expToLevel = calculateExpToLevel();
        _baseValue++;
    }

    public int AdjustBaseValue
    {
        get{return _baseValue + _buffValue;}
    }
}
