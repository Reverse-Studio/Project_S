using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager __instance__ = null;
    public static GameManager INSTANCE { get => __instance__; }
    public static bool IsPause = false;

    private GameObject orb;

    [SerializeField] private Player player;
    [SerializeField] private GameObject death;
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject button;

    private void Awake()
    {
        if (__instance__ != null) Destroy(__instance__.gameObject);

        orb = Resources.Load<GameObject>("Prefab/ExpOrb");
        pause.SetActive(false);
        death.SetActive(false);
        __instance__ = this;
    }

    private void Start()
    {
        SetStart();
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Vector3 location = new Vector3(i * 10, 0, j * 10);
                SpawnExpOrb(location, Random.Range(1, 15));
            }
        }
    }

    public void SpawnExpOrb(Vector3 location, int amount)
    {
        GameObject orbInst = Instantiate(orb, location, Quaternion.identity);
        ExpOrb expOrb = orbInst.GetComponent<ExpOrb>();
        expOrb.Amount = amount;
    }

    public void SetPause()
    {
        if (IsPause == false)
        {
            button.SetActive(false);
            Time.timeScale = 0f;
            IsPause = true;
        }
    }

    public void SetStart()
    {
        if (IsPause == true)
        {
            button.SetActive(true);
            Time.timeScale = 1f;
            IsPause = false;
        }
    }
}
