using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager __instance__ = null;
    public static GameManager INSTANCE { get => __instance__; }
    private GameObject orb;
    bool isPause = false;
    [SerializeField]
    private GameObject popup;
    private Button pause;
    private Button background;
    private Button resume;

    private void Awake()
    {
        orb = Resources.Load<GameObject>("Prefab/ExpOrb");
        popup.SetActive(false);
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

    private void Update()
    {
     
    }

    public void SpawnExpOrb(Vector3 location, int amount)
    {
        GameObject orbInst = Instantiate(orb, location, Quaternion.identity);
        ExpOrb expOrb = orbInst.GetComponent<ExpOrb>();
        expOrb.Amount = amount;
    }

    public void SetPause()
    {
        if(isPause == false)
        {
            Time.timeScale = 0f;
            isPause = true;
        }
    }

    public void SetStart()
    {
        if(isPause == true)
        {
            Time.timeScale = 1f;
            isPause = false;
        }
    }
}
