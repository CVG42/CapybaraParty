using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class BossController : MonoBehaviour
{
   public Transform[] transforms;
   public GameObject bullet;
   public float timeToShoot, countdown;
   public float timeToTP, countdownTP;

   public float bossHealt, currentHealth;
   public Image healthImage;
   private void Start()
   {
      
      transform.position = transforms[1].position;
      countdown = timeToShoot;
      countdownTP = timeToTP;
   }

   private void Update()
   {
      DamageBoss();
      Countdows();
      BossScale();

   }

   public void Countdows()
   {
      countdown -= Time.deltaTime;
      countdownTP -= Time.deltaTime;
      if (countdown < 0)
      {
         ShootPlayer();
         countdown = timeToShoot;
         
      }

      if (countdownTP <= 0)
      {
         countdownTP = timeToTP;
         Teleport();
      }
   }

   public void ShootPlayer()
   {
      GameObject spell = Instantiate(bullet, transform.position, Quaternion.identity);
   }

   public void Teleport()
   {
      var InicialPosition = Random.Range(0, transforms.Length);
      transform.position = transforms[InicialPosition].position;
   }

   public void DamageBoss()
   {
      currentHealth = GetComponent<MeleeEnemy>().HP;
      healthImage.fillAmount = currentHealth / bossHealt;
   }

   private void OnDestroy()
   {
      BossUI.instance.BossDesactivation();
   }

   public void BossScale()
   {
      if (transform.position.x > PlayerController.instance.transform.position.x)
      {
         transform.localScale = new Vector3(-4, 4, 4);
      }
      else
      {
         transform.localScale = new Vector3(4, 4, 4);
      }
   }
}
