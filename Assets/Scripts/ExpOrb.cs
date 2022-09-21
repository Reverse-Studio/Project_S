using UnityEngine;
<<<<<<< HEAD
public class ExpOrb : MonoBehaviour { 
    public int Amount; 
    
=======
public class ExpOrb : MonoBehaviour
{
    private GameObject Player;
    private ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (Config.MagnetDistance == -1 || Vector3.Distance(transform.position, Player.transform.position) <= Config.MagnetDistance)
        {
            transform.LookAt(Player.transform, Vector3.up);
            transform.Translate(Vector3.forward * Time.deltaTime * 10);
        }
    }

    private const int MaxAmount = 15;

    private int amount = 0;

    public int Amount
    {
        get => amount;
        set
        {
            float color = 1f - (float)value / MaxAmount;
            var main = particle.main;
            main.startColor = new ParticleSystem.MinMaxGradient(new Color(0, color, color));
            amount = value;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        //Player player = other.gameObject.GetComponent<Player>();
        //player.EXP += Amount;

        SoundManager.INSTANCE.Play("ExpUp", SoundManager.AudioType.EFFECT);
        Destroy(gameObject);
    }
>>>>>>> 163dc7882f6d9c0694f8721d3e0f0f10db238445
}