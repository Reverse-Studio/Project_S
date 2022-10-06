using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float health;
    private Transform target;

    private float invulnerable;

    // Start is called before the first frame update
    private void Start()
    {
        target = GameObject.Find("Player").transform;
        health = 100;
        invulnerable = 0;
    }

    // Update is called once per frame

    private void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > 1.0f)
        {
            transform.LookAt(target, Vector3.up);
            Vector3 velocity = Vector3.forward * Time.deltaTime * speed;
            velocity.y = 0;
            transform.Translate(velocity);
        }

        if (invulnerable > 0) invulnerable -= Time.deltaTime;
        else invulnerable = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        DoDamage(other);
    }

    private void DoDamage(Collider other)
    {
        if (!other.CompareTag("skill")) return;
        if (invulnerable > 0) return;

        Skill skill = other.gameObject.GetComponent<Skill>();
        health -= skill.Damage;

        invulnerable = 0.5f;

        if (health < 0)
        {
            Death();
            return;
        }
    }

    private void Death()
    {
        GameManager.INSTANCE.SpawnExpOrb(transform.position, 30);
        Destroy(gameObject);
    }
}