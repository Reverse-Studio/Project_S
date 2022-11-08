using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePositioner : MonoBehaviour
{
    /// <summary>
    /// 체크하면 DynamicPosition
    /// 체크하지 않으면 StaticPosition을 사용하게 된다
    /// </summary>
    public bool PositionMode;

    /// <summary>
    /// 정적 위치
    /// </summary>
    public Vector3 StaticPosition;

    /// <summary>
    /// 동적 위치
    /// </summary>
    public Transform DynamicPosition;

    public bool FixX;
    public bool FixY;
    public bool FixZ;

    private void LateUpdate()
    {
        Vector3 pivot = PositionMode ? DynamicPosition.position : StaticPosition;

        if (FixX) pivot.x = transform.position.x;
        if (FixY) pivot.y = transform.position.y;
        if (FixZ) pivot.z = transform.position.z;

        transform.position = pivot;
    }
}
