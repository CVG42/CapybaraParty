using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldItem : MonoBehaviour
{
    public static int _shield;
    public TextMeshProUGUI shieldCounter;
    
    void Start()
    {
        _shield = 0;
    }
    
    void Update()
    {
        shieldCounter.text = _shield.ToString();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Shield"))
        {
            _shield++;
        }
    }
}
