using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToMain : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene(0);
        
    }
    public void PlayerSetHealth(){
        player.currentHealth = 100;
    }
}
