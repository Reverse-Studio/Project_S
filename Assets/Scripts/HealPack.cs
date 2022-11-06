using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPack : Orb
{    
    protected override void onHitPlayer(Player player)
   {
        player.currentHealth += 20;
    }
}
