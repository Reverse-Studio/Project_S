using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private GameObject[] skills;
    public SkillButton[] cards;
    public void ChangeSKills()
    {
        Shuffle();
        for (int i = 0; i < 3; i++)
        {
            cards[i].Skill = skills[i].GetComponent<Skill>();
        }
    }

    // skills의 배열 내용을 바꿉니다
    void Swap(int a, int b)
    {
        GameObject temp;
        temp = skills[a];
        skills[a] = skills[b];
        skills[b] = temp;
    }

    void Shuffle()
    {
        for (int a = 0; a < 3; a++)
        {
            Swap(a, Random.Range(a, skills.Length));
        }
    }
}
