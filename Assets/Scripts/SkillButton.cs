using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public TextMeshProUGUI TMPText;
    public Image image;
    private Skill skill;
    //Skill=a
    public Skill Skill
    {
        get => skill; 
        set
        {
            skill = value;
            TMPText.text = skill.name;
            image.sprite = skill.SkillImage;
        }
    }

    public void OnCLick()
    {
        skill.SkillLevel++;
    }
}
