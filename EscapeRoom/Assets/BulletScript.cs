using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    private void OnCollisionEnter(Collision col)
    {
        var hit = col.gameObject;
        if(hit != null)
        {
            var combat = hit.GetComponent<CombatScript>();
            if (hit.tag == "Sheriff")
                combat.TakeDamage(5);
            else
                combat.TakeDamage(20);
            Destroy(gameObject);
        }
    }

}
