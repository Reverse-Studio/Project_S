using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    private static GameManager __instance__ = null;
    public static GameManager INSTANCE => __instance__;
    private GameObject orb;
    public bool isPause = false;
    public GameObject death;

    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject damage;

    private void Awake()
    {
        Debug.Log(__instance__);
        if (__instance__ != null) Destroy(__instance__.gameObject);

        orb = Resources.Load<GameObject>("Prefab/ExpOrb");
        pause.SetActive(false);
        death.SetActive(false);
        __instance__ = this;
    }

    private void Start()
    {
        SetStart();
        SoundManager.INSTANCE.Play("8bitmusic", SoundManager.AudioType.BGM);
    }

    private void Update()
    {
        if (player.currentHealth == 0 && isPause == false)
        {
            death.SetActive(true);
            pauseButton.SetActive(false);
            // Time.timeScale = 0f;
            isPause = true;
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
        if (isPause == false)
        {
            pauseButton.SetActive(false);
            // Time.timeScale = 0f;
            isPause = true;
        }
    }

    public void SetStart()
    {
        if (isPause == true)
        {
            pauseButton.SetActive(true);
            // Time.timeScale = 1f;
            isPause = false;
        }
    }

    public void SetPlayerHealth()
    {
        player.currentHealth = 100;
    }

    public void LevelUp()
    {
        if (isPause == false)
        {
            death.SetActive(true);
            pauseButton.SetActive(false);
            isPause = true;
            // Time.timeScale = 0f;
        }
    }

    public void ShowDamage(Vector3 position, float damage, Color color)
    {
        GameObject inst = Instantiate(this.damage);
        DamageEffect effect = inst.GetComponent<DamageEffect>();

        effect.damage = damage;
        effect.color = color;

        inst.transform.position = position + Vector3.up;
    }
}