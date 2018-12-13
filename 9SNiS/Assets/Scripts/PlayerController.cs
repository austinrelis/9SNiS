using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Transform jumpCheck, interactCheck;
    public float speed = 15.0f;
    Animator anim;
    public int health;
    float jumpTime, jumpDelay = .5f;
    public float jump;
    bool jumped;

    public float moveSpeed;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded = true;

    public float timeattack;
    public float starttimeattack;
    public Transform attackPos;
    public float attackrange;
    public LayerMask whatIsEnemy;
    public int damage;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
            if (Input.GetKeyDown(KeyCode.Space)&&grounded)
        {
            anim.SetTrigger("Jump");
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            //GetComponent<Rigidbody2D>().AddForce(transform.up * 200f);
            jumpTime = jumpDelay;
            
            jumped = true;
        }
        jumpTime -= Time.deltaTime;
        if (jumpTime <= 0 && grounded && jumped)
        {
            anim.SetTrigger("Land");
            jumped = false;
            grounded = true;
        }
        //if (Input.GetKey(KeyCode.D))
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        //if (Input.GetKey(KeyCode.A))
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Death");
        }
        if (timeattack <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("slash");
                print("attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackrange, whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyFollow>().TakeDamage(damage);
                }
                anim.SetTrigger("revert");
            }
            timeattack = starttimeattack;
        }
        else
        {
            timeattack = timeattack - Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackrange);
    }
    public void TakeDamage(int damage)
    {
        //Instantiate(blood, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damage taken");
        Debug.Log(health);
    }
}