using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    public PlayerHealth health;
    private Gradient gradient;
    int maxHealth = 100;
    public int currentHealth;
    private float countTime;
    public float delayTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        gradient.Evaluate(1f);
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
