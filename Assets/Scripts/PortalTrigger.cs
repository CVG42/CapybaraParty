using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    [SerializeField] private int totalEnemies;
    [SerializeField] private int eliminatedEnemies;
    public GameObject inactivePortal;
    public GameObject activatePortal;
    public GameObject abduction;

    private void Start()
    {
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void EliminatedEnemy()
    {
        eliminatedEnemies += 1;
        if (eliminatedEnemies == totalEnemies)
        {
            Destroy(inactivePortal);
            activatePortal.SetActive(true);
            abduction.SetActive(true);
        }
    }
}
