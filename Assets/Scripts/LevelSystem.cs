using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    private int level;
    private int experience;
    private int[] experienceToNextLevel = new int[] 
    { 30, 120, 300, 500, 800, 1200, 1800, 2500, 3200, 3800, 4500, 5200, 6000, 7000, 8200 };
    private int expAmount = 30;
    public GameObject expOrb;

    public LevelSystem() {
        level = 0;
        experience = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        AddExperience(expAmount);
    }

    public void AddExperience(int amount) {
        experience += amount;
        if(experience >= experienceToNextLevel[level]) {
            experience -= experienceToNextLevel[level];
            level++;
        }
    }

    public int GetLevelNumber() {
        return level;
    }

    public float GetExperienceNormalized() {
        return (float)experience / experienceToNextLevel[level];
    }
}
