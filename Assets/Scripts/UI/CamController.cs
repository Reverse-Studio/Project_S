using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform targetTransform;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        Vector3 pos = this.transform.position;
        this.transform.position = Vector3.Lerp(pos, targetTransform.position, 10 * Time.fixedDeltaTime);
    }
}
