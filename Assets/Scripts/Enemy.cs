using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform target;

    // Start is called before the first frame update
    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > 1.0f)
        {
            transform.LookAt(target, Vector3.up);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}