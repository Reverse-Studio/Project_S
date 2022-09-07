using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.2f)
        {
            timer -= 0.2f;
            SoundManager.INSTANCE.Play("Pop", SoundManager.AudioType.EFFECT);
        }
    }
}