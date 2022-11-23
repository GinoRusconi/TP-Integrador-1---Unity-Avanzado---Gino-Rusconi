using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class QuestCondition
{
    public enum ConditionType { Less, Greater, Equal}

    public string name;
    public int currentAmount;
    public int targetAmount;
    public ConditionType type;


    public void ClearCondition()
    {
        currentAmount = 0;
    }
    public bool Success()
    {
        return (type == ConditionType.Equal && currentAmount == targetAmount) ||
               (type == ConditionType.Greater && currentAmount > targetAmount) ||
               (type == ConditionType.Less && currentAmount < targetAmount);
    }
}
