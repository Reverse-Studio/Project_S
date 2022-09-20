using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSpin : MonoBehaviour
{
    public float StandardSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, StandardSpeed * Time.deltaTime, 0));    
    }
}
