using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCscript : MonoBehaviour
{
    public LayerMask playerLayer;
    public Vector2 size;

    public GameObject player;
    
    public GameObject speechBubble_quest;
    public GameObject speechBubble_complete;
    public string NPCName;

    private bool isEventTriggered;
    private bool isQuestCleared;
    // Start is called before the first frame update
    void Start()
    {
        isEventTriggered = false;
        isQuestCleared = false;
        speechBubble_quest.SetActive(false);
        speechBubble_complete.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isEventTriggered)
        {
            if(Physics2D.OverlapArea(new Vector2(transform.position.x - size.x, transform.position.y - size.y), 
        new Vector2(transform.position.x + size.x, transform.position.y + size.y), playerLayer))
            {
                speechBubble_quest.SetActive(true);
                isEventTriggered = true;
                player.GetComponent<QuestScript>().AccpetTestQuest();
            }
        }

        if(isEventTriggered && !isQuestCleared)
        {
            if(Physics2D.OverlapArea(new Vector2(transform.position.x - size.x, transform.position.y - size.y), 
        new Vector2(transform.position.x + size.x, transform.position.y + size.y), playerLayer))
            {
                if(player.GetComponent<QuestScript>().IsQuestDone(NPCName))
                {
                    speechBubble_quest.SetActive(false);
                    speechBubble_complete.SetActive(true);
                    isQuestCleared = true;
                }
            }
        }
    }
}
