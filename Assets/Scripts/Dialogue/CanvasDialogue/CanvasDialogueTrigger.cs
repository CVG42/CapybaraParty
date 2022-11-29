using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDialogueTrigger : MonoBehaviour
{
    public GameObject NPCDialogue;
    void Update()
    {
        if(DialogueTrigger._isTalking == true)
        {
            NPCDialogue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.L))
            {
                Destroy(NPCDialogue);
            }
        }
    }
}
