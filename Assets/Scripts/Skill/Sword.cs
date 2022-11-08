using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Skill
{
    protected override void Start()
    {
        SkillLevel = 1;
    }

    protected override void OnHit(Enemy enemy)
    {
        enemy.DoDamage(Damage);
    }
}
