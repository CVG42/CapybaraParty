using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    private GameObject player;
    private bool right = true;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
 
    }

    void Flip()
    {
        right = !right;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180);
    }
}
