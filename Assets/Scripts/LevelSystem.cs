using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public partial class Player : MonoBehaviour
{
    [SerializeField] private int level = 0;
    [SerializeField] private int experience = 0;
    [SerializeField] private int nextExp = 30;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject levelUp;
    [SerializeField] private SkillManager skillManager;


    public void AddExperience(int amount)
    {
        experience += amount;
        expSet.SetExp(experience);
        if (experience >= nextExp)
        {
            //SoundManager.INSTANCE.Play()
            Time.timeScale = 0f;
            experience -= nextExp;
            level++;
            nextExp = 30;// + level * (level + 1);
            expSet.SetMaxExp(nextExp);
            pauseButton.SetActive(false);
            skillManager.ChangeSKills(); // skill 랜덤 선택창
            levelUp.SetActive(true);
 
        }
    }

    public int Level { get => level; }

    public void SelectSkill()
    {
        pauseButton.SetActive(true);
        levelUp.SetActive(false);
        Time.timeScale = 1f;
    }

    public float experienceNormalized { get => (float)experience / nextExp; }
}
