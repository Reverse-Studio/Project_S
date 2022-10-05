using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public partial class Player : MonoBehaviour
{
    private int level = 0;
    private int experience = 0;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject levelUp;
    private int[] experienceToNextLevel = new int[] { 30, 120, 300, 500, 800, 1200, 1800, 2500, 3200, 3800, 4500, 5200, 6000, 7000, 8200 };

    public void AddExperience(int amount)
    {
        experience += amount;
        expSet.SetExp(experience);
        if (experience >= experienceToNextLevel[level])
        {
            experience -= experienceToNextLevel[level];
            level++;
            expSet.SetMaxExp(experienceToNextLevel[level]);
            pauseButton.SetActive(false);
            levelUp.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public int Level { get => level; }

    public void SelectSkill(){
        pauseButton.SetActive(true);
        levelUp.SetActive(false);
        Time.timeScale = 1f;
    }

    public float experienceNormalized { get => (float)experience / experienceToNextLevel[level]; }
}
