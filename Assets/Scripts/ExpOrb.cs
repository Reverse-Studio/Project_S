using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpOrb : Orb
{
    private GameObject player;
    protected override void onHitPlayer(Player player)
    {
        player.AddExperience(Amount);
        SoundManager.INSTANCE.Play("ExpUp", SoundManager.AudioType.EFFECT);
    }
}
