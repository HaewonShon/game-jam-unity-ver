using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    public LayerMask targetLayer;

    // TestQuest
    public bool isTestQuestAccepted;
    private bool isTestQuestDone;
    public GameObject TestQuestTarget;
    
    // Start is called before the first frame update
    void Start()
    {
        isTestQuestAccepted = false;
        isTestQuestDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isTestQuestDone && isTestQuestAccepted)
        {
            isTestQuestDone = Physics2D.IsTouching(GetComponent<Collider2D>(), TestQuestTarget.GetComponent<Collider2D>());
            Debug.Log("quest done");
        }
    }

    public void AccpetTestQuest()
    {
        isTestQuestAccepted = true;
    }

    public void CompleteTestQuest()
    {
        isTestQuestDone = true;
    }

    public bool IsQuestAccepted(string NPCname)
    {
        if(NPCname == "test")
        {
            return isTestQuestAccepted;
        }
        return false;
    }

    public bool IsQuestDone(string NPCname)
    {
        if(NPCname == "test")
        {
            return isTestQuestDone;
        }
        return false;
    }
}
