using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GiveUp : MonoBehaviour
{
    public Player player;

    public void OnclickGiveUp()
    {
        SceneManager.LoadScene(0);
        
    }
    public void PlayerSetHealth(){
        player.currentHealth = 100;
    }
}
