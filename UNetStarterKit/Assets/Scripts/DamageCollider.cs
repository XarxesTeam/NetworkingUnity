using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    private int damage = 0;
    
    void Start ()
    {
        damage = GetComponentInParent<PlayerController>().damage;
	}

    private void OnTriggerStay(Collider other)
    {
       if (other.gameObject.GetComponent<PlayerController>() != null && GetComponentInParent<PlayerController>().kicking)
       {
            GetComponentInParent<PlayerController>().kicking = false;
            //other.gameObject.GetComponent<PlayerController>().hp -= damage;
            other.GetComponent<PlayerController>().ChangeEnemyHp(damage);
       }
    }
}