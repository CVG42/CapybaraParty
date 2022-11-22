using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public int HP;
    public void TakeDmg(int dmg)
    {
        HP -= dmg;
        if (HP <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
        GameObject.FindGameObjectWithTag("PortalTrigger").GetComponent<PortalTrigger>().EliminatedEnemy();
    }
}
