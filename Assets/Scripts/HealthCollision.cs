using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollision : MonoBehaviour {

    public bool isDamaging;
    public float damage = 10;
    
    private void OnTriggerStay(Collider col)
    {
		Debug.Log (col.tag);
		if (col.tag == "Player") {
			col.SendMessage ((isDamaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damage);
		}
    }
    
}
