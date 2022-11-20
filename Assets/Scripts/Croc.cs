using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Croc : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3[] positions;
    [SerializeField] private bool capybaraOn;
    private int index;

    private void Start()
    {
        capybaraOn = false;
    }
    void Update()
    {
        if(capybaraOn == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);
            if (transform.position == positions[index])
            {
                if (index == positions.Length - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            capybaraOn = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            capybaraOn = false;
        }
    }
}
