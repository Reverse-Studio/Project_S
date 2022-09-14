using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public float spinSpeed = 10;
    public Transform Target;
    void Update()
    {
        gameObject.transform.position = Target.position;
        transform.RotateAround(Target.position, Vector3.up,Time.deltaTime * spinSpeed);
    }
}
