using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public TextMeshProUGUI TMPText;
    public Image skillImage;

    private Skill skill;
    public Skill Skill
    {
        get => skill; 
        set
        {
            skill = value;
            TMPText.text = skill.name;
        }
    }

    public void OnCLick()
    {
        skill.SkillLevel++;
    }
}
