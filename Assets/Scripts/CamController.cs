using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform targetTransform;
    public Vector3 CameraOffset;
    void Start()
    {
        
    }
    void Update()
    {
        transform.position = targetTransform.position + CameraOffset;
    }
}
