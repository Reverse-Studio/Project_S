using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] private float damage;
    public float Damage { get => damage; }

    /* Enemy가 처음 닿았을 때 호출 */
    protected virtual void OnHit(Enemy enemy) { }

    /* Enemy가 닿고 있을 때 호출 */
    protected virtual void OnHitting(Enemy enemy) { }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy")) return;
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        OnHit(enemy);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Enemy")) return;
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        OnHitting(enemy);
    }
}