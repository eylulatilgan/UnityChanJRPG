using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Stat {

    [SerializeField]    
    private float defaultValue;
    [SerializeField]
    private float currentValue;

    public float CurrentValue
    {
        get
        {
            return currentValue;
        }

        set
        {
            if(value > defaultValue)
            {
                currentValue = defaultValue;
            }
            else if (value < 0)
            {
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }
        }
    }

    public float DefaultValue
    {
        get
        {
            return defaultValue;
        }

        set
        {
            defaultValue = value;
        }
    }

    public void UpgradeStat(int upgradeValue)
    {
        defaultValue += upgradeValue;
    }

    public void DecreaseValue(float value)
    {
        if (currentValue - value > 0)
        {
            currentValue -= value ;
        }
        else
        {
            currentValue = 0;
        }
    }

}
