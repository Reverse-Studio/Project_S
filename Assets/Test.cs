using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        SoundManager.INSTANCE.Play("Pop", SoundManager.AudioType.BGM);
    }
}