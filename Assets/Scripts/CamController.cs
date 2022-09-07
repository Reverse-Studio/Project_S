using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform targetTransform;
    void Start()
    {
        
    }
    void Update()
    {
        Vector3 pos = this.transform.position;
        this.transform.position = Vector3.Lerp(pos, targetTransform.position, 0.4f);
    }
}
