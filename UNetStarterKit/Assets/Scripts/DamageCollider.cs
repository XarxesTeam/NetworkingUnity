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
      // if (other.gameObject.GetComponent<PlayerController>() != null && GetComponentInParent<PlayerController>().kicking)
      // {
      //     other.gameObject.GetComponent<PlayerController>().hp -= damage;
      //     //GetComponentInParent<PlayerController>().ChangeEnemyHp(other.gameObject.GetComponent<PlayerController>().hp);
      //     GetComponentInParent<PlayerController>().kicking = false;
      // }
    }
}
