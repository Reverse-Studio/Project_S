using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wing : Skill
{
    private int defaultLevel = 12;

    protected override void SetSkillLevel(int level)
    {
        PlayerController.moveSpeed = (level + defaultLevel) * 1.1f;
    }
}
