using UnityEngine;

public class Razer : Skill
{
    [SerializeField] private float RazerDuringTime = 2;
    [SerializeField] private float LaserCoolTime = 5;

    private float timer = 0;
    private bool isCoolTime = false;

    private GameObject razer;
    private Collider damageTrigger;
    private GameObject player;

    protected override void Start()
    {
        player = GameObject.Find("Player");
        damageTrigger = GetComponent<Collider>();
        razer = transform.Find("razer").gameObject;
    }

    private void Update()
    {
        if(SkillLevel == 0) return;

        transform.position = player.transform.position + Vector3.up * 2;
        timer += Time.deltaTime;

        if (isCoolTime)
        {
            if (timer >= LaserCoolTime)
            {
                timer -= LaserCoolTime;
                isCoolTime = false;
                SetLaserActive(true);
            }
        }
        else
        {
            if (timer >= RazerDuringTime)
            {
                timer -= RazerDuringTime;
                isCoolTime = true;
                SetLaserActive(false);
            }
        }
    }

    private void SetLaserActive(bool condition)
    {
        if (condition)
        {
            transform.rotation = player.transform.rotation;
            damageTrigger.enabled = true;
            razer.SetActive(true);
        }
        else
        {
            damageTrigger.enabled = false;
            razer.SetActive(false);
        }
    }

    protected override void OnHitting(Enemy enemy)
    {
        enemy.DoDamage(Damage);
    }

    protected override void SetSkillLevel(int level)
    {
        transform.localScale = new Vector3(level, level, 50);
        Damage = level * 15f; 
    }
}
