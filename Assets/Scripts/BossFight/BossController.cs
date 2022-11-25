using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
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
                    StartCoroutine(ShipStatuses());
                    break;
                default:
                    break;
            }
        }
    }
}