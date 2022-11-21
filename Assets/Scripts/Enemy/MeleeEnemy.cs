using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public int HP;
    public static int _damage = 1;

    public void TakeDmg(int dmg)
    {
        HP -= dmg;
        if(HP <= 0)
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
