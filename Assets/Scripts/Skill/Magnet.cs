using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Skill
{
    protected override void SetSkillLevel(int level)
    {
        ExpOrb.MagnetDistance = (level + 1);
    }
}
