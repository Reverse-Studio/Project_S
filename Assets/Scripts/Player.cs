using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public partial class Player : MonoBehaviour
{
    public ExpSet expSet;
    public TextMeshProUGUI playerLevel;
    public PlayerHealth health;
    public GameManager gameManager;
    int maxHealth = 100;
    public int currentHealth;
    private float countTime;
    public float delayTime = 0.5f;

    private void Start()
    {
        currentHealth = maxHealth;
        health.SetMaxHealth(maxHealth);
        expSet.SetMaxExp(nextExp);
        expSet.SetExp(0);
    }

    private void Update()
    {
        if (GameManager.INSTANCE.isPause) return;

        playerLevel.text = level.ToString();
        if (countTime < delayTime)
            countTime += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (countTime >= delayTime)
            {
                GameManager.INSTANCE.ShowDamage(transform.position, 10, Color.red);
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
