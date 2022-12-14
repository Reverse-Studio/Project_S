using UnityEngine;
public abstract class Orb : MonoBehaviour
{
    [SerializeField] private PlayerHealth CPlayerHealth;
    private GameObject Player;
    private ParticleSystem particle;
    public static float MagnetDistance;
    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        Player = GameObject.Find("Player");
    }
    private void Update()
    {
        if (MagnetDistance == -1 || Vector3.Distance(transform.position, Player.transform.position) <= MagnetDistance)
        {
            transform.LookAt(Player.transform, Vector3.up);
            transform.Translate(Vector3.forward * Time.deltaTime * 10);
        }
    }

    private const int MaxAmount = 5;

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

        Player player = other.gameObject.GetComponent<Player>();
        onHitPlayer(player);
        Destroy(gameObject);
    }

    protected abstract void onHitPlayer(Player player);
}