using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager __instance__ = null;
    public static GameManager INSTANCE { get => __instance__; }

    private GameObject orb;

    private void Awake()
    {
        orb = Resources.Load<GameObject>("Prefab/ExpOrb");
        DontDestroyOnLoad(gameObject);
        __instance__ = this;
    }

    private void Start()
    {
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
}
