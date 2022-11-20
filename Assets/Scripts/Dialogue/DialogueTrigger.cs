using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueTrigger;
    public GameObject[] dialogue;
    public bool isInteracting;
    public static bool _isTalking;

    private void Start()
    {
        isInteracting = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInteracting == true)
        {
            dialogueTrigger.SetActive(false);
            dialogue[0].SetActive(true);
            dialogue[1].SetActive(true);
            _isTalking = true;
        }
    }

    private void exitDialogue()
    {
        dialogue[0].SetActive(false);
        dialogue[1].SetActive(false);
        _isTalking = false;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            dialogueTrigger.SetActive(true);
            isInteracting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueTrigger.SetActive(false);
        isInteracting = false;
        exitDialogue();
    }
}
