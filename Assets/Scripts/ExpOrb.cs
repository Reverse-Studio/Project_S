using UnityEngine;
public class ExpOrb : MonoBehaviour
{
    private GameObject Player;
    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    private void Update()
    {
        transform.LookAt(Player.transform, Vector3.up);
        transform.Translate(Vector3.forward * Time.deltaTime * 10);
    }

    public int Amount;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("asdf");
        if (other.tag != "Player") return;

        //Player player = other.gameObject.GetComponent<Player>();
        //player.EXP += Amount;

        SoundManager.INSTANCE.Play("ExpUp", SoundManager.AudioType.EFFECT);
        Destroy(gameObject);
    }
}