using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    private int level = 0;
    private int experience = 0;

    private int[] experienceToNextLevel = new int[] { 30, 120, 300, 500, 800, 1200, 1800, 2500, 3200, 3800, 4500, 5200, 6000, 7000, 8200 };

    public void AddExperience(int amount)
    {
        experience += amount;
        if (experience >= experienceToNextLevel[level])
        {
            experience -= experienceToNextLevel[level];
            level++;
        }
    }

    public int Level { get => level; }

    private void OnCollisionEnter(Collision other)
    {

    }

    public float experienceNormalized { get => (float)experience / experienceToNextLevel[level]; }
}
