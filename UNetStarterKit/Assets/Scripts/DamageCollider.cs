using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
       if (other.gameObject.GetComponent<PlayerController>() != null && GetComponentInParent<PlayerController>().kicking)
       {
            GetComponentInParent<PlayerController>().enemyHitGO = other.gameObject;
            GetComponentInParent<PlayerController>().enemyHit = true;
            GetComponentInParent<PlayerController>().kicking = false;
       }
    }
}