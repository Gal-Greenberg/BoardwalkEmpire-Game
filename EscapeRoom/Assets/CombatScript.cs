using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour {

    public GameObject gate;

    public const int MaxHealth = 100;
    public int health = MaxHealth;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            if (gameObject.tag == "Sheriff")
            {
                Animator animator = gate.GetComponent<Animator>();
                animator.SetBool("OpenGate", true);
            }
            Destroy(gameObject);
        }

    }
}
