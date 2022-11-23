using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest", order = 1)]

public class Quest : ScriptableObject
{
    public QuestCondition[] winConditions;



    public void ClearCondition()
    {
        foreach (var condition in winConditions)
        {
            condition.ClearCondition();
        }
    }


    public void AddAmount(string name, int amount)
    {
        foreach (var condition in winConditions)
        {
            if (condition.name == name)
            {
                condition.currentAmount += amount;
            }
        }
    }

    public bool Success()
    {
        foreach (var conditions in winConditions)
        {
            if (!conditions.Success()) return false; 
        }
        return true;
    }
}
