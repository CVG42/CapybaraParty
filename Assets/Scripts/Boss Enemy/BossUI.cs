using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    public GameObject Bosspanel;

    public static BossUI instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        Bosspanel.SetActive(false);
    }

    public void BossActivator()
    {
        Bosspanel.SetActive(true);
    }

    public void BossDesactivation()
    {
        Bosspanel.SetActive(false);
    }
}
