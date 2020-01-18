using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public GameObject player;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("trigger called");
        if(!player.GetComponent<QuestScript>().IsQuestDone("test") && player.GetComponent<QuestScript>().IsQuestAccepted("test"))
        {
            player.GetComponent<QuestScript>().CompleteTestQuest();
            Debug.Log("done");
        }
    }
}
