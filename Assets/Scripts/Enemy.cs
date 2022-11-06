using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private bool isDead;

    private Transform target;
    private CharacterController charController;

    private float invulnerable;

    // Start is called before the first frame update
    private void Start()
    {
        charController = GetComponent<CharacterController>();
        target = GameObject.Find("Player").transform;
        health = 100;
        invulnerable = 0;
    }

    // Update is called once per frame

    private void Update()
    {
        if (GameManager.INSTANCE.isPause) return;
        if (isDead) return;

        if (Vector3.Distance(transform.position, target.position) > 1.0f)
        {
            transform.LookAt(target, Vector3.up);
            Vector3 velocity = transform.TransformDirection(Vector3.forward * Time.deltaTime * speed);
            charController.Move(velocity);
        }

        if (invulnerable > 0) invulnerable -= Time.deltaTime;
        else invulnerable = 0;
    }

    public void DoDamage(float DamageAmount)
    {
        if (isDead) return;

        if (invulnerable > 0) return;
        invulnerable = 0.1f;

        health -= DamageAmount;
        GameManager.INSTANCE.ShowDamage(transform.position, DamageAmount, Color.white);

        if (health <= 0)
        {
            Death();
            return;
        }
    }

    private void Death()
    {
        isDead = true;
        GameManager.INSTANCE.SpawnExpOrb(transform.position + Vector3.up, Random.Range(3, 5));
        Animator animator = GetComponent<Animator>();
        Collider collider = GetComponent<Collider>();
        Destroy(collider);
        animator.SetBool("isDead", true);
        Destroy(gameObject, animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
    }
}