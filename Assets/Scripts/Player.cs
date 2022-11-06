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

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        expSet.SetMaxExp(nextExp);
        expSet.SetExp(0);
        health.SetMaxHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        playerLevel.text = level.ToString();
        if (countTime < delayTime)
            countTime += Time.deltaTime;
        if(currentHealth > 100){
            currentHealth = 100;
        }
        health.SetHealth(currentHealth);
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
