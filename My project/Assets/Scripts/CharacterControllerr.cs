using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerr : MonoBehaviour
{
    
    //[SerializeField] private float jumpForge = 5f;
    //private bool grounded;
    private Rigidbody2D _rigidbody2D;
    //private bool started;
    private Animator _animator;
    bool canAttack = true;
    bool faceRight = false;
    public int damage;
    RaycastHit2D hit;
    public Vector3 offset;
    Vector2 forward;
    //public int turnDelay;
    public int turnDelay;
    //bool deneme = false;



    private void Awake()
    {

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        //started = true;
        //grounded = true;
    }

    public void Attack()//ATIÞ MESAFESÝ SORULACAK
    {
       if (!faceRight)
       {
            forward = transform.TransformDirection(Vector2.right * -2);
        }

        else
        {
           forward = transform.TransformDirection(Vector2.right * 2);
       }
        canAttack = false;



        RaycastHit2D hit = Physics2D.Raycast(transform.position + offset, forward, 10f);

        if (hit)
        {
            
            if (hit.transform.tag == "enemy")
            {   
                hit.transform.GetComponent<enemyhealth>().GetDamage(damage);//dikkat
                Debug.Log("Hello: ");
            }

        }
        

        StartCoroutine(AttackDelay());

    }

    private void Update()
    {
        float hareket_hizi = 6f;
        if (Input.GetKey(KeyCode.A))
        {
            // A tuþuna týklandýðý zaman yapýlacak iþlemler.
            this.transform.Translate(-(hareket_hizi * Time.deltaTime), 0, 0);
            // Karakterin sola doðru gitmesini saðladýk.
            _animator.SetFloat("Speed", -6f);

            if (Input.GetKeyDown(KeyCode.W))
            {
                // W tuþuna týklandýðý zaman yapýlacak iþlemler.
                this.transform.Translate(0, 3, 0);
                // Karakterin yukarý doðru gitmesini saðladýk.
                _animator.SetBool("Grounded", false);
                //Grounded = false;
                _animator.SetTrigger("Jump");

            }

        }


    
        else if (Input.GetKey(KeyCode.D))
        {
            // D tuþuna týklandýðý zaman yapýlacak iþlemler.
            this.transform.Translate(hareket_hizi * Time.deltaTime, 0, 0);
            // Karakterin saða doðru gitmesini saðladýk.

            _animator.SetFloat("Speed", 6f);

            if (Input.GetKeyDown(KeyCode.W))
            {
                // W tuþuna týklandýðý zaman yapýlacak iþlemler.
                this.transform.Translate(0, 3, 0);
                // Karakterin yukarý doðru gitmesini saðladýk.
                _animator.SetBool("Grounded", false);
                //Grounded = false;
                _animator.SetTrigger("Jump");

            }

            }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            // W tuþuna týklandýðý zaman yapýlacak iþlemler.
            this.transform.Translate(0, 3, 0);
            // Karakterin yukarý doðru gitmesini saðladýk.
            _animator.SetBool("Grounded",false);
            //Grounded = false;
            _animator.SetTrigger("Jump");

            if (Input.GetKey(KeyCode.D))
            {
                // D tuþuna týklandýðý zaman yapýlacak iþlemler.
                this.transform.Translate(hareket_hizi * Time.deltaTime, 0, 0);
                // Karakterin saða doðru gitmesini saðladýk.

                _animator.SetFloat("Speed", 6f);


            }

        }
        else
        {
            this.transform.Translate(0, 0, 0);
            _animator.SetBool("Grounded", true);
            //Grounded = true;
            _animator.SetFloat("Speed", 0);

        }

        if (Input.GetKeyDown(KeyCode.F) && canAttack)
        {
            //deneme = true;
            Attack();
            _animator.SetTrigger("deneme");
            
        }
        
    }
    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(0.5f);
        canAttack = true;

    }

}
