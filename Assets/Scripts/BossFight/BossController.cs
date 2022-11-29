using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using Unity.Mathematics;
using Random = UnityEngine.Random;


namespace BossFight
{
    
    public enum Shipboss
    {
        Talking,
        Idle,
        Melee,
        Lacermelee,
        Aoe,
        Dead
    }
    
    public class BossController : MonoBehaviour
    {
        public Shipboss status;
        private Animator _animator;
        public float statusCH;
        [Header("LacerAoe Shoot Atack")] 
        public GameObject lacerFA;
        public float startLFA = 1.10f;
        public float lfaTime = 2f;
        public float[] targets;
        
        
        

        private void Start()
        {
            status = Shipboss.Idle;
            _animator = GetComponent<Animator>();
            StartCoroutine(ShipStatuses());
        }

        IEnumerator ShipStatuses()
        {
            var randomAttack = Random.Range(1, 5);
            yield return new WaitForSeconds(statusCH);

            switch (randomAttack)
            {
                case 1:
                    status = Shipboss.Idle;
                    break;
                case 2:
                    status = Shipboss.Melee;
                    break;
                case 3:
                    status = Shipboss.Lacermelee;
                    break;
                case 4:
                    status = Shipboss.Aoe;
                    break;
                default:
                    break;
            }
            statusChanger();
        }


        public void statusChanger()
        {
            switch (status)
            {
                case Shipboss.Idle:
                    _animator.SetTrigger("Idle_Boss");
                    StartCoroutine(ShipStatuses());
                    break;
                case Shipboss.Melee:
                    _animator.SetTrigger("Melee");
                    StartCoroutine(ShipStatuses());
                    break;
                case Shipboss.Lacermelee:
                    _animator.SetTrigger("Lacermelee");
                    
                    StartCoroutine(ShipStatuses());
                    break;
                case Shipboss.Aoe:
                    _animator.SetTrigger("AOE");
                    StartCoroutine(LacerAOE());
                    StartCoroutine(ShipStatuses());
                    break;
                default:
                    break;
            }
            
            
            
            
        }

        IEnumerator LacerAOE()
        {
            statusCH = 12;
            yield return new WaitForSeconds(startLFA);
            StartCoroutine(lacerShootings());
        }

        IEnumerator lacerShootings()
        {
            int counter = 0;

            while (counter < 12)
            {
            var position = Random.Range(0, 11);
            yield return new WaitForSeconds(lfaTime);
            Instantiate(lacerFA, new Vector2(targets[position], 12f), Quaternion.identity);
            counter++;
            if (counter > 20)
            {
                break;
            }
            
            }

            statusCH = 5;

        }
        
    }
}