using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDuckUFOTrigger : MonoBehaviour
{
    [SerializeField] private GameObject readyDialogue;
    private bool isInteracting;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && isInteracting)
        {
            Destroy(readyDialogue);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            readyDialogue.SetActive(true);
            isInteracting = true;
        }
    }
}
