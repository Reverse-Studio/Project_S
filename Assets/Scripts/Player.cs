using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    public PlayerHealth health;
    public ExpSet expSet;
    int maxHealth = 100;
    public int currentHealth;
    private float countTime;
    public float delayTime = 0.5f;
    private int[] maxExp = {30, 120, 300, 500, 800, 1200, 1800, 2500, 3200, 3800, 4500, 5200, 6000, 7000, 8200};
    public int currentExp;
    public int lv = 0;
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

    void main(){
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == ("Chunk"))
        {
            Debug.Log(col);
        }

        if (col.tag == ("Exp")){

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
        if (other.CompareTag("Exp")){

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
