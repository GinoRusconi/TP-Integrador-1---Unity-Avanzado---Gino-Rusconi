using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    private Quest[] quests;
    private int amountQuest;
    public TextMeshProUGUI prefQuestUI;

    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        quests = ManagerControllerLvl1.Instance.quests;
        prefQuestUI.text = $"Total Enemigos muertos {quests[0].winConditions[0].currentAmount}";
    }

    void Start()
    {
        prefQuestUI.text = $"Total Enemigos muertos {quests[0].winConditions[0].currentAmount}";
        quests = ManagerControllerLvl1.Instance.quests;
        foreach (Quest quest in quests)
        {
            amountQuest++;
        }

        //if (amountQuest > 1)
        //{
        //    for (int i = 1; i < quests.Length; i++)
        //    {

        //    }
        //}
    }

    void Update()
    {
        
    }
}
