using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    private GameObject player;
    private Vector3 enemyCreatePosition = new Vector3(0, 0, 0);
    private int randValue;

    [SerializeField] private float Radius;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public float SpawnDelay = 2;
    private float spawnCoolDown = 0;

    private void Update()
    {
        if (GameManager.INSTANCE.isPause) return;

        spawnCoolDown += Time.deltaTime;

        if (spawnCoolDown >= SpawnDelay)
        {
            float a = Random.Range(-Mathf.PI, Mathf.PI);
            float x = Mathf.Sin(a) * Radius + player.transform.position.x;
            float z = Mathf.Cos(a) * Radius + player.transform.position.z;
            Instantiate(enemy, new Vector3(x, 0, z), Quaternion.identity);

            spawnCoolDown -= SpawnDelay;
        }
    }
}
