using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject caca;
    [SerializeField] private AudioSource shoot;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && AmmoManager._ammo > 0)
        {
            shoot.Play();
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(caca, shootingPoint.position, shootingPoint.rotation);
        AmmoManager._ammo--;
    }
}
