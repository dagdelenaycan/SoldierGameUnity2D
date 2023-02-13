using UnityEngine;
using UnityEngine.UI;

public class characterstats : MonoBehaviour
{


    public Image[] kalp;

    public int health = 3;
    int maxhealth = 3;


    public void Damage(int amount)
    {
        kalp[health - 1].enabled = false;
        health -= amount;
    }

    public void Regen(int amount)
    {
        health += amount;

        for(int i = 0; i < health; i++)
        {
            kalp[i].enabled = true;
        }
    }

    private void Update()
    {
        if (health > maxhealth)
        {
            health = maxhealth;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (health > 0)
            {
                Damage(1);
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (health < maxhealth)
            {
                Regen(1);
            }
        }
    }

}
