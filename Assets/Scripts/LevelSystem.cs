using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem
{
    private int level;
    private int experience;
    private int experienceToNextLevel;

    public LevelSystem() {
        level = 1;
        experience = 0;
        experienceToNextLevel = 100;
    }

    public void AddExperience(int amount) {
        experience += amount;
        if(experience >= experienceToNextLevel) {
            level++;
            experience -= experienceToNextLevel;
        }
    }

    public int GetLevelNumber() {
        return level;
    }

    public float GetExperienceNormalized() {
        return (float)experience / experienceToNextLevel;
    }
}
