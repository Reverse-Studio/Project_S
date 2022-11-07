using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform targetTransform;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        Vector3 pos = this.transform.position;
        this.transform.position = new Vector3(targetTransform.position.x, transform.position.y,targetTransform.position.z);
    }
}
