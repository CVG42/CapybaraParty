using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DuckDialogue : MonoBehaviour
{
    public string[] sentences;
    public TextMeshProUGUI texts;
    public float typingSpeed;
    private int index;

    private void Start()
    {
        texts.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (texts.text == sentences[index])
            {
                NextSentence();
            }
            else
            {
                StopAllCoroutines();
                texts.text = sentences[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(Typing());
    }

    IEnumerator Typing()
    {
        foreach (char c in sentences[index].ToCharArray())
        {
            texts.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            texts.text = string.Empty;
            StartCoroutine(Typing());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
