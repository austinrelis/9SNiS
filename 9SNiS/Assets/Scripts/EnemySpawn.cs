using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public GameObject enemy;
    public Transform enemyPos;
    private float repeatRate = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D (Collider2D BoxCollider2D)
    {
        if (BoxCollider2D.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("EnemySpawner", 0.5f, repeatRate);
            Destroy(gameObject, 11);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    void EnemySpawner()
    {
        Instantiate(enemy, enemyPos.position, enemyPos.rotation);
    }
}
