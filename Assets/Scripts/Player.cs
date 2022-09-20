using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerHealth health;

    int maxHealth = 100;
    int currentHealth;
    private float countTime;
    public float delayTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        health.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            countTime += Time.deltaTime;
            if (countTime >= delayTime) {
                countTime -= delayTime;
                currentHealth -= 10;
                health.SetHealth(currentHealth);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            countTime = 0;
        }
    }
}
