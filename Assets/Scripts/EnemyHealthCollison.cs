using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthCollison : MonoBehaviour {

    public bool isDamaging1;
    public float damage1 = 50;

    private void OnTriggerStay(Collider col)
    {
        Debug.Log(col.tag);
        if (col.tag == "Mutant")
        {
            col.SendMessage((isDamaging1) ? "TakeDamage1" : "HealDamage1", Time.deltaTime * damage1);
        }
    }

}
