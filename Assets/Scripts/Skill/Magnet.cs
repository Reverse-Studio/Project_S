using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Skill
{
    protected override void SetSkillLevel(int level)
    {
        Orb.MagnetDistance = (level + 1);
    }
}
