using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellZone : Skill
{
    [SerializeField] private GameObject player;

    protected override void Start()
    {
        SkillLevel = 1;
    }
    
    private void LateUpdate()
    {
        transform.position = player.transform.position;
    }

    protected override void OnHitting(Enemy enemy)
    {
        enemy.DoDamage(Damage);
    }

    protected override void SetSkillLevel(int level)
    {
        Damage = baseDamage + (level - 1) * 2;
        transform.localScale = new Vector3(level + 4, level + 4, level + 4);
    }
}
