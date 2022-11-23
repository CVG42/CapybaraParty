using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckDialogue1 : MonoBehaviour
{
    public GameObject NPCDialogue;
    void Update()
    {
        if (DialogueTrigger._isTalking == true)
        {
            NPCDialogue.SetActive(true);
        }
        else
        {
            NPCDialogue.SetActive(false);
        }
    }
}
