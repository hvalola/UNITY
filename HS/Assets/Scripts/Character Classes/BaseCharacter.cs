﻿using UnityEngine;
using System.Collections;
using System;

public class BaseCharacter : MonoBehaviour 
{
    private string _name;
    private int _level;
    private uint _freeExp;

    private Attribute[] _primaryAttribute;
    private Vital[] _vital;
    private Skill[] _skill;


    void Awake()
    {
        _name = string.Empty;
        _level = 0;
        _freeExp = 0;

        _primaryAttribute = new Attribute[Enum.GetValues(typeof(Attribute)).Length];
        _vital = new Vital[Enum.GetValues(typeof(Vital)).Length];
        _skill = new Skill[Enum.GetValues(typeof(Skill)).Length];

        SetupPrimaryAttributes();
        SetupVitals();
        SetupSkills();

    }
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }

    public uint FreeExp
    {
        get { return _freeExp; }
        set { _freeExp = value; }
    }

    public void AddExp(uint exp)
    {
        _freeExp += exp;
        CalculateLevel();
    }

    public void CalculateLevel()
    {

    }

    private void SetupPrimaryAttributes()
    {
        for (int cnt = 0; cnt <_primaryAttribute.Length; cnt++)
        {
            _primaryAttribute[cnt] = new Attribute();
        }

    }

    private void SetupVitals()
    {
        for (int cnt = 0; cnt < _vital.Length; cnt++)
        {
            _vital[cnt] = new Vital();
        }
    }

    private void SetupSkills()
    {
        for (int cnt = 0; cnt < _skill.Length; cnt++)
        {
            _skill[cnt] = new Skill();
        }
    }

    public Attribute GetPrimaryAttribute(int index)
    {
        return _primaryAttribute[index];
    }

    public Vital GetVital(int index)
    {
        return _vital[index];
    }

    public Skill GetSkill(int index)
    {
        return _skill[index];
    }

    private void SetupVitalModifiers()
    {
        /*ModifyingAttribute health = new ModifyingAttribute();
        health.attribute = GetPrimaryAttribute((int)AttributeName.Constitution);
        health.ratio = 0.5f;
        GetVital((int)VitalName.Health).AddModifier(health);*/

        GetVital((int)VitalName.Health).AddModifier(new ModifyingAttribute ( GetPrimaryAttribute((int)AttributeName.Constitution),0.5f ));
        GetVital((int)VitalName.Energy).AddModifier(new ModifyingAttribute ( GetPrimaryAttribute((int)AttributeName.Constitution), 1.0f ));
        GetVital((int)VitalName.Mana).AddModifier(new ModifyingAttribute ( GetPrimaryAttribute((int)AttributeName.Willpower),  1.0f ));
    }

    private void SetupSkillModifiers()
    {
      /*  ModifyingAttribute MaleeOffenceModifier1 = new ModifyingAttribute();
        ModifyingAttribute MaleeOffenceModifier2 = new ModifyingAttribute();

        MaleeOffenceModifier1.attribute = GetPrimaryAttribute((int)AttributeName.Might);
        MaleeOffenceModifier1.ratio = 0.33f;

        MaleeOffenceModifier2.attribute = GetPrimaryAttribute((int)AttributeName.Willpower);
        MaleeOffenceModifier2.ratio = 0.33f;*/

        //Malee Offence
        GetSkill((int)SkillName.Malee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Might),0.33f));
        GetSkill((int)SkillName.Malee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Ninbleness), 0.33f));

        //Malee Deffence
        GetSkill((int)SkillName.Malee_Deffence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), 0.33f));
        GetSkill((int)SkillName.Malee_Deffence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), 0.33f));
        //Magic Offence
        GetSkill((int)SkillName.Magic_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), 0.33f));
        GetSkill((int)SkillName.Magic_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), 0.33f));

        //Magic Deffence
        GetSkill((int)SkillName.Magic_Deffence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), 0.33f));
        GetSkill((int)SkillName.Magic_Deffence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), 0.33f));

        //Range Offence
        GetSkill((int)SkillName.Ranged_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), 0.33f));
        GetSkill((int)SkillName.Ranged_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), 0.33f));

        //Range Deffence
        GetSkill((int)SkillName.Ranged_Deffence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), 0.33f));
        GetSkill((int)SkillName.Ranged_Deffence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Ninbleness), 0.33f));
    }

    public void StatUpdate()
    {
        for(int cnt = 0; cnt <_vital.Length; cnt++)
        {
            _vital[cnt].Update();
        }

        for (int cnt = 0; cnt < _skill.Length; cnt++)
        {
            _skill[cnt].Update();
        }
    }
}