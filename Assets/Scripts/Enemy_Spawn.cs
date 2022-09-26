using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    private Vector3 enemyCreatePosition = new Vector3(0, 0, 0);
    private int randValue;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(CreateEnemy());
    }

    IEnumerator CreateEnemy()
    {
        while (true)
        {
            randValue = Random.Range(-10, 10);
            enemyCreatePosition = player.transform.position + new Vector3(randValue, 0, randValue);
            Instantiate(enemy, enemyCreatePosition, player.transform.rotation);
            yield return new WaitForSeconds(1.0f);
        }
    }
    void Update()
    {
        
    }
}
