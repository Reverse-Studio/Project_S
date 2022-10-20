using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] protected float baseDamage;
    [SerializeField] private float damage;
    [SerializeField] private int skillLevel;

    private void Start()
    {
        SetSkillLevel(0);
    }

    public float Damage { get => damage; set => damage = value; }
    public int SkillLevel { get => skillLevel; set { skillLevel = value; } }

    /* Enemy가 처음 닿았을 때 호출 */
    protected virtual void OnHit(Enemy enemy) { }

    /* Enemy가 닿고 있을 때 호출 */
    protected virtual void OnHitting(Enemy enemy) { }

    /* 스킬 레벨에따라 정해지는 뷁 */
    protected virtual void SetSkillLevel(int level) { }

    private void OnTriggerEnter(Collider other)
    {
        if (skillLevel == 0) return;
        if (!other.CompareTag("Enemy")) return;
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        OnHit(enemy);
    }

    private void OnTriggerStay(Collider other)
    {
        if (skillLevel == 0) return;
        if (!other.CompareTag("Enemy")) return;
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        OnHitting(enemy);
    }
}