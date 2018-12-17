using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour {

    private int damage = 0;

	void Start ()
    {
        damage = GetComponentInParent<PlayerController>().damage;
	}
	
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)  // And kicking? TODO
            other.gameObject.GetComponent<PlayerController>().hp -= damage;
    }
}
