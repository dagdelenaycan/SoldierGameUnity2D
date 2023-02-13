using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    public int health;
    //private bool olduMu;

    public void GetDamage(int amount)
    {
        health -= amount;
        //olduMu = true;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
