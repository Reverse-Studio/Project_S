using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Joystick controller;
    public Transform player;
    public Transform camPivot;

    private void Awake()
    {
        controller = this.GetComponent<Joystick>();
    }

    void Update()
    {
        Vector3 inputDir = Vector3.forward * controller.Vertical;
        inputDir += Vector3.right * controller.Horizontal;

        if(inputDir == Vector3.zero) return;

        Vector3 conDirAngle = Quaternion.LookRotation(inputDir).eulerAngles;
        Vector3 camPivotAngle = camPivot.eulerAngles;

        Vector3 moveAngle = Vector3.up * (conDirAngle.y + camPivotAngle.y);

        player.rotation = Quaternion.LookRotation(inputDir);
        player.Translate(Vector3.forward * Time.fixedDeltaTime * moveSpeed);
    }
}
