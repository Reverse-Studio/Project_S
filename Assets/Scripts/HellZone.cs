using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellZone : Skill
{
    [SerializeField] private GameObject player;

    private void Update()
    {
        transform.position = player.transform.position;
    }

    protected override void OnHitting(Enemy enemy)
    {
        enemy.DoDamage(Damage);
    }
}
