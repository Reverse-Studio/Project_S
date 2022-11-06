using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Skill
{
    protected override void OnHit(Enemy enemy)
    {
        enemy.DoDamage(Damage);
    }
}
