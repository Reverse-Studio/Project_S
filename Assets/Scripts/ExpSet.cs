using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Player : MonoBehaviour
{
    public Slider slider;

    public void SetMaxExp(int MaxExp){
        slider.maxValue = MaxExp;
        slider.value = 0;
    }

    public void SetExp(int Exp){
        slider.value = Exp;
    }
}
