using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    public float speed;
    public int health;
    public int damage;
    public Transform attackPos;
    public float attackrange;
    public LayerMask whatIsEnemy;


    private Transform target;
    public GameObject blood;
	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
	}

    public void TakeDamage(int damage)
    {
        //Instantiate(blood, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damage taken");
        Debug.Log(health);
    }

    void OnTriggerEnter2D(Collider2D BoxCollider2D)
    {
       // if (BoxCollider2D.gameObject.CompareTag("Player"))
        //{
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackrange, whatIsEnemy);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<PlayerController>().TakeDamage(damage);
            }
      //  }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackrange);
    }
}
