using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public GameObject GElectricBall;
    public GameObject GLazer;
    public GameObject GHellZone;
    private GameObject[] skills;
    public SkillButton[] cards;
    // Start is called before the first frame update
    void Start()
    {
        skills = new GameObject[] { GElectricBall, GLazer, GHellZone };
    }

    // Update is called once per frame
    void Update()
    {

    }

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
