using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emote : MonoBehaviour
{
    public GameObject emote;

    void Update()
    {
        if(DialogueTrigger._isTalking == true)
        {
            emote.SetActive(false);
        }
        else
        {
            emote.SetActive(true);
        }
    }
}
