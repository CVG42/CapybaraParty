using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Reload : MonoBehaviour
{
    public bool isOnWater;
    public LayerMask water;
    [SerializeField] private AudioSource poop;
    public GameObject bubble;

    private void Start()
    {
        isOnWater = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && isOnWater == true)
        {
            poop.Play();
            ReloadWeapon();
            bubble.SetActive(true);
        }
    }

    private void ReloadWeapon()
    {

        if (ScoreManager._score >= 5)
        {
            ScoreManager._score -= 5;
            AmmoManager._ammo += 7;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Water"))
        {
            isOnWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isOnWater = false;
        bubble.SetActive(false);
    }
}
