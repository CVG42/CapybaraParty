using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBounce : MonoBehaviour
{
    public float bounce;
    public Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            GameObject.FindGameObjectWithTag("PortalTrigger").GetComponent<PortalTrigger>().EliminatedEnemy();
            rb.velocity = new Vector2(rb.velocity.x, bounce);
        }
    }
}
