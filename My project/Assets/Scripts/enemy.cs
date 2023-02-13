using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed;
    bool faceRight = false;
    public int turnDelay;
    public int health;
    Animator animator;
    Rigidbody2D rb;

    Vector2 forward;

    public Vector3 offset;
    public int damage;
    RaycastHit2D hit;
    bool canAttack = true;

    private void Start()
    {
        StartCoroutine(SwitchDirections());
    }


    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    IEnumerator SwitchDirections()
    {
        yield return new WaitForSeconds(turnDelay);
        Switch();
    }
    private void Switch()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
        speed *= -1;
        StartCoroutine(SwitchDirections());


    }
    public void TakeDamage(int amount)
    {
        //rb.AddForce(Vector2.right * 700);
        health -= amount;
        if (health <= 0)
            Destroy(gameObject);

    }

    

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(0.5f);
        canAttack = true;

    }

}
