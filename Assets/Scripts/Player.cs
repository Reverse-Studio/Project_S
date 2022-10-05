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
        health.SetMaxHealth(maxHealth);
        expSet.SetMaxExp(experienceToNextLevel[level]);
        expSet.SetExp(0);
    }

    // Update is called once per frame
    void Update()
    {
        playerLevel.text = level.ToString();
    }

    void main(){
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == ("Chunk"))
        {
            Debug.Log(col);
        }

        if (col.tag == ("Exp")){
            AddExperience(30);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            countTime += Time.deltaTime;
            if (countTime >= delayTime)
            {
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
