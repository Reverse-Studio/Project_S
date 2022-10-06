using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBall : Skill
{
    [SerializeField] private GameObject player;
    [SerializeField] private float radius;
    [SerializeField] private float speed;
    private float rotation = 0;

    private void Start()
    {
        Debug.Log("Hello World");
    }


    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        rotation += Time.deltaTime * speed;
        if (rotation > Mathf.PI * 2) rotation -= Mathf.PI * 2;

        Vector3 pos = player.transform.position;

        float x = Mathf.Cos(rotation) * radius + pos.x;
        float y = 1.5f;
        float z = Mathf.Sin(rotation) * radius + pos.z;

        transform.position = new Vector3(x, y, z);
    }
}
