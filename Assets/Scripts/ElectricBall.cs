using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBall : Skill
{
    [SerializeField] private GameObject player;
    [SerializeField] private float radius;
    [SerializeField] private float speed;

    private float angle = 0;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        angle += Time.deltaTime * speed;
        if (angle > Mathf.PI * 2) angle -= Mathf.PI * 2;

        Vector3 pos = player.transform.position;

        float x = Mathf.Cos(angle) * radius + pos.x;
        float y = 1.5f;
        float z = Mathf.Sin(angle) * radius + pos.z;

        transform.position = new Vector3(x, y, z);
    }

    protected override void OnHit(Enemy enemy)
    {
        enemy.DoDamage(Damage);
    }
}