using UnityEngine;

public class Laser : Skill
{
    [SerializeField] private float LaserDuringTime = 2;
    [SerializeField] private float LaserCoolTime = 5;

    private float timer = 0;
    private bool isCoolTime = false;

    private GameObject laser;
    private Collider damageTrigger;
    private GameObject player;

    protected override void Start()
    {
        player = GameObject.Find("Player");
        damageTrigger = GetComponent<Collider>();
        laser = transform.Find("laser").gameObject;
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
            if (timer >= LaserDuringTime)
            {
                timer -= LaserDuringTime;
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
            laser.SetActive(true);
        }
        else
        {
            damageTrigger.enabled = false;
            laser.SetActive(false);
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
