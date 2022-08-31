using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP_Bar : MonoBehaviour
{
    public Transform player;
    public Image hpbar;
    public float maxHp;
    public float currenthp;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + new Vector3(0, 0, 0);
        hpbar.fillAmount = currenthp / maxHp;
    }
}
