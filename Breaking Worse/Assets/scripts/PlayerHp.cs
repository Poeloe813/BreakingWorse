using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public float Health = 3f; // Initialize Health
    [SerializeField] private float cooldownTime;
    // cooldown tijd

    private float nextAttackTime;

    private bool isCoolingDown() => Time.time < nextAttackTime;
    void Start()
    {

    }

    void Update()
    {
        if (isCoolingDown())
        {
            return;
        }

        Debug.Log("health is " + Health);


        StartCooldown();
    }
    private void StartCooldown()
    {
        nextAttackTime = Time.time + cooldownTime;
    }

    //    public void Playerhealth()
    //    {
    //        Health -= 1; // Decrement Health
    //        Debug.Log("au!");
    //        if (Health <= 0)
    //        {
    //            Destroy(gameObject); // Destroy the player object if Health is 0 or less
    //        }
    //    }
}