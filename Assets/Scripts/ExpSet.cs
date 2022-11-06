using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpSet : MonoBehaviour
{
    private Slider slider;
    private float exp;
    private float currentVelocity;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        float curScore = Mathf.SmoothDamp(slider.value, exp, ref currentVelocity, 10 * Time.deltaTime);
        slider.value = curScore;
    }

    public void SetMaxExp(int MaxExp)
    {
        slider.maxValue = MaxExp;
        exp = 0;
        slider.value = 0;
        currentVelocity = 0;
    }

    public void SetExp(int Exp)
    {
        exp = Exp;
    }
}
